using UnityEngine;
using UnityEngine.EventSystems;
using AttTypeDefine;
using DG.Tweening;
public class AnimCtrl : MonoBehaviour
{

    #region Paras
    public Vector2[] animPerArray;
    public UI_JoyStick joyStickInst;
    FinalSkillBtn finalSkillInst;

    public AnimatorManager animatorMgr;
    Animator _Anim;
    public Animator Anim => (_Anim);
    int curAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string curAnimName;
    string attackPre = "Base Layer.Attack";
    string skillPre = "Base Layer.Skill";
    bool isReady = true;

    Camera Cam;

    EmmaSword weaponInst;

    bool _IsPlaying;
    public bool IsPlaying => (_IsPlaying);

    eSkillType skillType;
    #endregion

    #region Sys Funcs


    private void Start()
    {
        _Anim = GetComponent<Animator>();
        animatorMgr.OnStart(this);

        finalSkillInst = joyStickInst.finalSkillBtnInst;

        Cam = Camera.main;

        var weaponGo = GlobalHelper.FindGoByName(gameObject, "greatesword");
        if (null != weaponGo)
        {
            weaponInst = weaponGo.GetComponent<EmmaSword>();
            weaponInst.OnStart(this);
        }

        joyStickInst.finalSkillBtnInst.pressDown.AddListener((a) => OnFinalSkillBegin(a));
        joyStickInst.finalSkillBtnInst.onDragEvent.AddListener((a) => OnFinalSkillDrag(a));
        joyStickInst.finalSkillBtnInst.pressUp.AddListener((a) => OnFinalSkillEnd(a));

        LoadFinalSkillArrow();
    }
    private void Update()
    {
        UpdateSkillInput();
    }
    
    #endregion

    #region Cast Attack

    void UpdateSkillInput()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.K))
        {
            CastSkill(eSkillType.eAttack);
        }
#endif
    }
    void CastSkillReady()
    {
        isReady = true;
    }
    void CastSkill(eSkillType type)
    {
        if (!isReady) return;
        skillType = type;
        if (type == eSkillType.eAttack)
        {
            if (curAnimAttackIndex > MaxAnimAttackIndex) curAnimAttackIndex = MinAnimAttackIndex;
            curAnimName = attackPre + curAnimAttackIndex.ToString();
        }
        else if(type == eSkillType.eSkill1)
        {
            curAnimName = skillPre + ((int)skillType).ToString();
        }
        animatorMgr.StartAnimation(curAnimName, CastSkillReady, CastSkillBegin, CastSkillEnd, CastSkillEnd1);
    }

    void CastSkillBegin()
    {
        _IsPlaying = true;
        if (skillType == eSkillType.eAttack)
        {
            isReady = false;
            //计算攻击index
            curAnimAttackIndex++;
        }
    }

    void CastSkillEnd()
    {
        if (skillType == eSkillType.eAttack)
        {
            curAnimAttackIndex = MinAnimAttackIndex;
            isReady = true;
        }
        _IsPlaying = false;

    }
    void CastSkillEnd1()
    {
        if (skillType == eSkillType.eAttack)
        {
            if (curAnimAttackIndex <= 1)
            {
                //Debug.LogError("Log Error");
                // return;
                curAnimAttackIndex = 2;
            }
            if (skillType == eSkillType.eAttack)
            {
                var item = animPerArray[curAnimAttackIndex - 2];

                weaponInst.OnStartWeaponCtrl(Anim, item.x, item.y);
            }
        }
    }

    #endregion

    #region FinalSkill
    Vector3 finalSkillDir;

    public float finalSkillDis = 1f;

    bool isUsingSkill = false;
    public void ModifyFSV(int value)
    {
        //increase angry value. -> UI
        joyStickInst.OnModifyFSV(value);
    }
    public void OnFinalSkillBegin(PointerEventData data)
    {
        if (isUsingSkill) return;
        isUsingSkill = false;

        Time.timeScale = 0.1f;
        _GroundArrow.SetActive(true);

        finalSkillDir = finalSkillInst.Dir.x * Cam.transform.right + finalSkillInst.Dir.y * Cam.transform.forward;
        if (finalSkillDir == Vector3.zero) finalSkillDir = transform.forward;
        finalSkillDir.y = 0;

        _GroundArrow.transform.forward = finalSkillDir;
    }
    public void OnFinalSkillDrag(PointerEventData data)
    {
        finalSkillDir = finalSkillInst.Dir.x * Cam.transform.right + finalSkillInst.Dir.y * Cam.transform.forward;
        if (finalSkillDir == Vector3.zero) finalSkillDir = transform.forward;
        finalSkillDir.y = 0;

        _GroundArrow.transform.forward = finalSkillDir;
    }
    public void OnFinalSkillEnd(PointerEventData data)
    {
        Time.timeScale = 1.0f;

        _GroundArrow.SetActive(false);
        finalSkillDir = Vector3.zero;

        joyStickInst.OnModifyFSV(-100);

        //播放技能动画
        CastSkill(eSkillType.eSkill1);

        var finalPos = transform.position + _GroundArrow.transform.forward * finalSkillDis;
        transform.DOMove(finalPos,0.7f).OnComplete(()=> {
            isUsingSkill = false;
        });
        transform.DOLookAt(finalPos,0.35f);
    }

    #endregion

    #region Load Arrow
    private GameObject _GroundArrow;
    public GameObject GroundArrow => (_GroundArrow);
    void LoadFinalSkillArrow()
    {
        var obj = Resources.Load("Weapons/GroundArrow");
        _GroundArrow = Instantiate(obj,transform.position,transform.rotation) as GameObject;
        _GroundArrow.transform.parent = transform;
        _GroundArrow.transform.localPosition = Vector3.zero;
        _GroundArrow.transform.localRotation = Quaternion.identity;
        _GroundArrow.transform.localScale = Vector3.one;

        _GroundArrow.SetActive(false);
    }
    #endregion
}
