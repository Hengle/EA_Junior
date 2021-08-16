using UnityEngine;
using AttTypeDefine;

public class SEAction_SkillInfo : SEAction_BaseAction
{
    [HideInInspector]
    public eSkillBlindType skillBlindType;
    [HideInInspector ]
    public string objName;
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
