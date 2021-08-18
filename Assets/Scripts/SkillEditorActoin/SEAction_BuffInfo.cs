using UnityEngine;

public class SEAction_BuffInfo : SEAction_BaseAction
{
    public override void TrigAction()
    {
        Destroy(gameObject); 
    }

    public void SetOwner(GameObject owner,GameObject target = null)
    {
        SEAction_DataStore[] ses = gameObject.GetComponentsInChildren<SEAction_DataStore>();
        foreach (var i in ses)
        {
            i.owner = owner;
            i.buffInfo = this;
            i.target = target;
        }
    }
}
