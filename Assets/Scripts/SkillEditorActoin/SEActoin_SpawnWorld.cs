using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEActoin_SpawnWorld : SEAction_BaseAction
{
    SEAction_DataStore se;

    [HideInInspector]
    public GameObject effectspawnInst;

    [HideInInspector]
    public string socketName;

    [HideInInspector]
    public float effectDestroyDelay;

    [HideInInspector]
    public Vector3 offSet;
    [HideInInspector]
    public Vector3 offRot;

    GameObject owner;

    public override void TrigAction()
    {
        se = GetComponent<SEAction_DataStore>();
        owner = se.owner;

        var socket = GlobalHelper.FindGoByName(owner, socketName);
        if (null == socket)
        {
            socket = owner;
        }

        //spawn effect
        var effect = Instantiate(effectspawnInst);

        var des = effect.GetComponent<SEAction_Destruction>();
        if(null != des)
        {
            des.delay = effectDestroyDelay;
            des.OnStart();
        }

        effect.transform.rotation = socket.transform.rotation;
        effect.transform.Rotate(offRot,Space.Self);

        effect.transform.position = socket.transform.position;
        effect.transform.Translate(offSet,Space.Self);
        //修改特效的位置：当前的拥有者 + offset + rotoffset

    }
}
