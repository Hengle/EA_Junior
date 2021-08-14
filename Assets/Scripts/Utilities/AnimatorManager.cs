using UnityEngine;
using AttTypeDefine;

public class AnimatorManager : MonoBehaviour
{
    #region Sys Funcs

    AnimCtrl animInst;
    StateMachine stateInst;
    NotifySkill skillReadyInst;

    #endregion

    public void OnStart(AnimCtrl tmp)
    {
        animInst = tmp;
        stateInst = animInst.Anim.GetBehaviour<StateMachine>();

    }
    public void StartAnimation(string animName,NotifySkill SkillReady,NotifySkill SkillBegin,NotifySkill SkillEnd)
    {
        animInst.Anim.SetTrigger(animName);

        skillReadyInst = SkillReady;

        stateInst.ClearAllCallbacks();

        stateInst.RegisterCallback(eTrigSkillState.eTrigBegin,SkillBegin);
        stateInst.RegisterCallback(eTrigSkillState.eTrigEnd, ()=>
        {
            this.InvokeNextFrame(() =>
            {
                stateInst.RegisterCallback(eTrigSkillState.eTrigEnd, SkillEnd);
            });
        });
    }

    void EventSkillReady()
    {
        skillReadyInst();
    }
}
