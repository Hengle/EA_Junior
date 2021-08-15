using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAction_SkillInfo : SEAction_BaseAction
{
    public override void TrigAction()
    {
        base.TrigAction();
        Destroy(gameObject);
    }

    public void SetOwner(GameObject Owner)
    {
        SEAction_DataStore[] ses = gameObject.GetComponentsInChildren<SEAction_DataStore>();
        foreach(var i in ses)
        {
            i.owner = Owner;
        }
    }
}
