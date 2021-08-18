using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAction_BuffSpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;

    [HideInInspector]
    public GameObject effectspawnInst;

    [HideInInspector]
    public float effectDestroyDelay;

    [HideInInspector]
    public float effectScale = 1;
    public override void TrigAction()
    {
        se = GetComponent<SEAction_DataStore>();

        var defencer = se.target;
        var defencerBasePlayer = defencer.GetComponent<BasePlayer>();

        //spawn effect
        var effect = Instantiate(effectspawnInst);
        effect.transform.localScale = Vector3.one * effectScale;
        var des = effect.GetComponent<SEAction_Destruction>();


        if (null != des)
        {
            des.delay = effectDestroyDelay;
            des.OnStart();
        }

        effect.transform.position = defencerBasePlayer.closestHitPoint;

    }
}
