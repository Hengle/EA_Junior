using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAction_DataStore : MonoBehaviour
{
    [HideInInspector]
    public GameObject owner;    
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public SEAction_SkillInfo skillInfo;
    [HideInInspector]
    public SEAction_BuffInfo buffInfo;
}
