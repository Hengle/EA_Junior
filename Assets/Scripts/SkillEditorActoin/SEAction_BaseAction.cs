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

    public void OnStart()
    {
        if(trigType == eTrigType.eCondition)
        {
            startTime = Time.time;
            isTriggerd = true;
        }
    }

    private void Update()
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
}
