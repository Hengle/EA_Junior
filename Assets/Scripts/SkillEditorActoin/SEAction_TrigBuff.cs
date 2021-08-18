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
        //ʵ����Buff
        var path = GlobalHelper.CombingString(constBuffPath, buffID);
        var obj = Resources.Load(path);
        var buffInst = Instantiate(obj) as GameObject;
        var buffInfo = buffInst.GetComponent<SEAction_BuffInfo>();

        //�����ߣ����ܵ�ӵ����
        //�������ߣ����������ĺϷ�����
        buffInfo.SetOwner(ae.owner,ae.target);
    }
}
