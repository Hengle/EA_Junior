using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAction_TrigBuff : SEAction_BaseAction
{
    string constBuffPath = "Buffs/";
    public string buffID;
    public override void TrigAction()
    {
        var ae = GetDataStore();
        //实例化Buff
        var path = GlobalHelper.CombingString(constBuffPath, buffID);
        var obj = Resources.Load(path);
        var buffInst = Instantiate(obj) as GameObject;
        var buffInfo = buffInst.GetComponent<SEAction_BuffInfo>();

        //攻击者：技能的拥有者
        //被攻击者：技能碰到的合法敌人
        buffInfo.SetOwner(ae.owner,ae.target);
    }
}
