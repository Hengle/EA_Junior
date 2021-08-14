using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class StateMachine : StateMachineBehaviour
{
    bool isCurTransition;
    bool isLastTransition;
    AnimatorStateInfo LastStateInfo;
    Dictionary<eTrigSkillState, List<NotifySkill>> skillDic = new Dictionary<eTrigSkillState, List<NotifySkill>>();

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isCurTransition = animator.IsInTransition(layerIndex);
        if (!isCurTransition && stateInfo.normalizedTime % 1.0f < LastStateInfo.normalizedTime % 1.0f)
        {
            //CastSkillEnd
            TrigAction(eTrigSkillState.eTrigEnd);
        }
        if (isCurTransition && !isLastTransition)
        {
            //CastSkillBegin
            TrigAction(eTrigSkillState.eTrigBegin);
        }
        if (!isCurTransition && isLastTransition)
        {
            //CastSkillEnd1
            TrigAction(eTrigSkillState.eTrigEnd);
        }

        isLastTransition = isCurTransition;
        LastStateInfo = stateInfo;
    }

    void TrigAction(eTrigSkillState state)
    {
        if (skillDic.ContainsKey(state))
        {
            var list = skillDic[state];
            while (list.Count > 0)
            {
                var ns = list[0];
                list.Remove(ns);
                ns();
            }
        }
    }

    public void RegisterCallback(eTrigSkillState state, NotifySkill action)
    {
        List<NotifySkill> list;
        if (skillDic.ContainsKey(state))
        {
            list = skillDic[state];
            list.Add(action);
        }
        else
        {
            list = new List<NotifySkill>();
            list.Add(action);
            skillDic.Add(state, list);
        }
    }

    public void ClearAllCallbacks()
    {
        if (null == skillDic) return;
        List<NotifySkill> list;
        for (var i = eTrigSkillState.eTrigBegin; i <= eTrigSkillState.eTrigEnd; i++)
        {
            if (skillDic.ContainsKey(i))
            {
                list = skillDic[i];
                list.Clear();
            }
        }
    }
}
