using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    #region Sys Funcs

    public Vector2[] animPerArray;

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
    private void Start()
    {
        _Anim = GetComponent<Animator>();
        animatorMgr.OnStart(this);
        var weaponGo = GlobalHelper.FindGoByName(gameObject, "greatesword");
        if (null != weaponGo) weaponInst = weaponGo.GetComponent<EmmaSword>();
        
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
            Debug.LogError("Log Error");
            return;
        }
        var item = animPerArray[curAnimAttackIndex - 2];

         weaponInst.OnStartWeaponCtrl(Anim, item.x,item.y);
    }

    #endregion
}
