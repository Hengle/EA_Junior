using UnityEngine;
using UnityEngine.EventSystems;

public class AnimCtrl : MonoBehaviour
{

    #region Paras
    public Vector2[] animPerArray;
    public UI_JoyStick joyStickInst;

    public AnimatorManager animatorMgr;
    Animator _Anim;
    public Animator Anim => (_Anim);
    int curAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string curAnimName;
    string attackPre = "Base Layer.Attack";
    bool isReady = true;

    EmmaSword weaponInst;

    bool _IsPlaying;
    public bool IsPlaying => (_IsPlaying);
    #endregion

    #region Sys Funcs
    private void Start()
    {
        _Anim = GetComponent<Animator>();
        animatorMgr.OnStart(this);
        var weaponGo = GlobalHelper.FindGoByName(gameObject, "greatesword");
        if (null != weaponGo)
        {
            weaponInst = weaponGo.GetComponent<EmmaSword>();
            weaponInst.OnStart(this);
        }

        joyStickInst.finalSkillBtnInst.pressDown.AddListener((a)=>OnFinalSkillBegin(a));
        joyStickInst.finalSkillBtnInst.onDragEvent.AddListener((a)=>OnFinalSkillDrag(a));
        joyStickInst.finalSkillBtnInst.pressUp.AddListener((a)=>OnFinalSkillEnd(a));
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
            CastSkill();

        }
#endif
    }
    void CastSkillReady()
    {
        isReady = true;
    }
    void CastSkill()
    {
        if (!isReady) return;
        if (curAnimAttackIndex > MaxAnimAttackIndex) curAnimAttackIndex = MinAnimAttackIndex;
        curAnimName = attackPre + curAnimAttackIndex.ToString();
        animatorMgr.StartAnimation(curAnimName,CastSkillReady,CastSkillBegin,CastSkillEnd,CastSkillEnd1);
    }

    void CastSkillBegin()
    {
        _IsPlaying = true;
        isReady = false;
        //¼ÆËã¹¥»÷index
        curAnimAttackIndex++;
    }

    void CastSkillEnd()
    {
        curAnimAttackIndex = MinAnimAttackIndex;
        _IsPlaying = false;
        isReady = true;
    }
    void CastSkillEnd1()
    {
        //Weapon Ctrol
        if(curAnimAttackIndex <= 1)
        {
            //Debug.LogError("Log Error");
            // return;
            curAnimAttackIndex = 2;
        }
        var item = animPerArray[curAnimAttackIndex - 2];

         weaponInst.OnStartWeaponCtrl(Anim, item.x,item.y);
    }

    #endregion

    #region FinalSkill
    public void ModifyFSV()
    {
        //increase angry value. -> UI
        joyStickInst.OnModifyFSV();
    }
    public void OnFinalSkillBegin(PointerEventData data)
    {
        Debug.Log("OnFinalSkillBegin");
    }
    public void OnFinalSkillDrag(PointerEventData data)
    {
        Debug.Log("OnFinalSkillDrag");
    }
    public void OnFinalSkillEnd(PointerEventData data)
    {
        Debug.Log("OnFinalSkillEnd");
    }

    #endregion
}
