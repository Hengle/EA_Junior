using System.Collections;
using UnityEngine;

public class EmmaSword : MonoBehaviour
{
    //根据角色的攻击动画百分比来控制大刀的碰撞属性

    #region Para
    BoxCollider boxColl;
    Animator anim;
    float startPer;
    float endPer;
    float curPer;
    float lastPer;
    AnimatorStateInfo stateInfo;
    #endregion

    #region System Funcs
    private void Start()
    {
        boxColl = GetComponent<BoxCollider>();
        boxColl.enabled = false;
    }
    #endregion

    #region Weapon Manager
    AnimCtrl animCtrlInst;
    public void OnStart(AnimCtrl animCtrl)
    {
        animCtrlInst = animCtrl;
    }
    public void OnStartWeaponCtrl(Animator _anim,float _startPer,float _endPer)
    {
        //检测当前动画的百分比
        anim = _anim;
        startPer = _startPer;
        endPer = _endPer;
        StopAllCoroutines();
        StartCoroutine(WaitToPlayAnim());
    }

    IEnumerator WaitToPlayAnim()
    {

        while(true)
        {
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            curPer = stateInfo.normalizedTime % 1.0f;
            if(curPer>=startPer && lastPer < startPer)
            {
                boxColl.enabled = true;
            }
            else if(curPer > endPer && lastPer <= endPer)
            {
                boxColl.enabled = false;
                break;
            }
            lastPer = curPer;
            yield return null;
        }

    }


    //在有效活性期间内，如果碰到敌人，直接关闭活性
    private void OnTriggerEnter(Collider other)
    {
        var enemyActor = other.gameObject.GetComponent<NpcActor>();
        if(null != enemyActor)
        {
            enemyActor.GetHit();

            //player increase angry value
            animCtrlInst.ModifyFSV();
        }
    }
    #endregion
}
