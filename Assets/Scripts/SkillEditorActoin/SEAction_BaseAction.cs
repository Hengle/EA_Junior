using UnityEngine;
using AttTypeDefine;

public class SEAction_BaseAction : MonoBehaviour
{
    [HideInInspector]
    public eTrigType trigType;
    [HideInInspector]
    public float delay;
    float startTime = 0f;
    bool isTriggerd = false;

    private void Start()
    {
        if(trigType == eTrigType.eAuto)
        {
            startTime = Time.time;
            isTriggerd = true;
        }
    }

    public virtual void OnStart()
    {
        if(trigType == eTrigType.eCondition)
        {
            startTime = Time.time;
            isTriggerd = true;
        }
    }

    protected virtual void Update()
    {
        if (!isTriggerd) return;
        if (Time.time - startTime >= delay)
        {
            isTriggerd = false;
            TrigAction();
        }
    }

    public virtual void TrigAction()
    {

    }

    public SEAction_DataStore GetDataStore()
    {
        var ds = gameObject.GetComponent<SEAction_DataStore>();
        return ds;
    }
}
