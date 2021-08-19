using UnityEngine;
using UnityEngine.EventSystems;
using AttTypeDefine;
using DG.Tweening;
public class AnimCtrl : BasePlayer
{

    #region Paras
    Vector2 item;
    public UI_JoyStick joyStickInst;

    public int TYPEID = 1000;

    FinalSkillBtn finalSkillInst;

    public AnimatorManager animatorMgr;
    int curAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string curAnimName;
    string attackPre = "Base Layer.Attack";
    string skillPre = "Base Layer.Skill";
    string skillPrePath = "Skills/";
    bool isReady = true;
    bool isFinishFinalSkill = false;

    Camera Cam;

    //EmmaSword weaponInst;

    bool _IsPlaying;
    public bool IsPlaying => (_IsPlaying);

    eSkillType skillType;
    #endregion

    #region Sys Funcs

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        typeId = TYPEID;
        animatorMgr.OnStart(this);

        finalSkillInst = joyStickInst.finalSkillBtnInst;

        Cam = Camera.main;

       //var weaponGo = GlobalHelper.FindGoByName(gameObject, "greatesword");
       // if (null != weaponGo)
       // {
       //     weaponInst = weaponGo.GetComponent<EmmaSword>();
       //     weaponInst.OnStart(this);
       // }

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
            //加载特效
            //规则判定：动画如何与特效绑定在一起，怎么知道播放a动画，加载a特效？
            //1001
            var path = skillPrePath + (1000 + curAnimAttackIndex).ToString();
            var skillPrefab = GlobalHelper.InstantiateMyPrefab(path,transform.position + Vector3.up * 1f,Quaternion.identity);

            var skillInfo = skillPrefab.GetComponent<SEAction_SkillInfo>();
            skillInfo.SetOwner(gameObject);
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
        //if (skillType == eSkillType.eAttack)
        //{
        //    if (curAnimAttackIndex <= 1)
        //    {
        //        //Debug.LogError("Log Error");
        //        // return;
        //        curAnimAttackIndex = 2;
        //    }
        //    if (skillType == eSkillType.eAttack)
        //    {
        //        item = animPerArray[curAnimAttackIndex - 2];

        //        weaponInst.OnStartWeaponCtrl(Anim, item.x, item.y);
        //    }
        //}
        //else if (skillType == eSkillType.eSkill1)
        //{
        //    item = animSkillPerArray[(int)(skillType - 1)];
        //}
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

        isFinishFinalSkill = true;

        Time.timeScale = 0.1f;
        _GroundArrow.SetActive(true);

        finalSkillDir = finalSkillInst.Dir.x * Cam.transform.right + finalSkillInst.Dir.y * Cam.transform.forward;
        if (finalSkillDir == Vector3.zero) finalSkillDir = transform.forward;
        finalSkillDir.y = 0;

        _GroundArrow.transform.forward = finalSkillDir;
    }
    public void OnFinalSkillDrag(PointerEventData data)
    {
        if (!isFinishFinalSkill)
            return;

        finalSkillDir = finalSkillInst.Dir.x * Cam.transform.right + finalSkillInst.Dir.y * Cam.transform.forward;
        if (finalSkillDir == Vector3.zero) finalSkillDir = transform.forward;
        finalSkillDir.y = 0;

        _GroundArrow.transform.forward = finalSkillDir;
    }
    public void OnFinalSkillEnd(PointerEventData data)
    {
        if (!isFinishFinalSkill)
            return;

        Time.timeScale = 1.0f;

        _GroundArrow.SetActive(false);
        finalSkillDir = Vector3.zero;

        joyStickInst.OnModifyFSV(-100);

        //播放技能动画
        CastSkill(eSkillType.eSkill1);

        var finalPos = transform.position + _GroundArrow.transform.forward * finalSkillDis;
        transform.DOMove(finalPos,0.7f).OnComplete(()=> {
            isUsingSkill = false;
            isFinishFinalSkill = false;
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
