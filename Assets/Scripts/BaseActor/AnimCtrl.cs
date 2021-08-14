using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    #region Sys Funcs

    public AnimatorManager animatorMgr;
    Animator _anim;
    public Animator Anim => (_anim);
    int curAnimAttackIndex = 1;
    int MinAnimAttackIndex = 1;
    int MaxAnimAttackIndex = 3;
    string curAnimName;
    string attackPre = "Base Layer.Attack";
    bool isReady = true;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        animatorMgr.OnStart(this);
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
        animatorMgr.StartAnimation(curAnimName,CastSkillReady,CastSkillBegin,CastSkillEnd);
    }

    void CastSkillBegin()
    {
        isReady = false;
        curAnimAttackIndex++;
        //加载特效

        //计算当前攻击index
    }

    void CastSkillEnd()
    {
        curAnimAttackIndex = MinAnimAttackIndex;
        isReady = true;
    }

    #endregion
}
