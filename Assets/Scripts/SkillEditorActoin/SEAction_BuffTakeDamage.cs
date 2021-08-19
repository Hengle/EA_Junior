using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class SEAction_BuffTakeDamage : SEAction_BaseAction
{
//  public bool isTakeDamage = true;
    [HideInInspector]
    public eStateID animID;
    /*
     * 
     * µÙ—™
     * 
     * ≤•∑≈ ‹…À∂Øª≠
     * 
     */
    public override void TrigAction()
    {
        var ds = GetDataStore();

        var attacker = ds.owner.GetComponent<BasePlayer>();
        var defencer = ds.target.GetComponent<BasePlayer>();

        //1:hp
        //2:attack
        /*       if (isTakeDamage)
               {
                   //hp defencer
                   //attack attacker

               }*/
        var hp = defencer.BaseAttr[ePlayerAttr.eAttack];
        var attack = attacker.BaseAttr[ePlayerAttr.eAttack];
        hp -= attack;
        if (hp <= 0)
        {
            defencer.BaseAttr[ePlayerAttr.eHP] = 0;
        }
        else
        {
            defencer.BaseAttr[ePlayerAttr.eHP] = hp;
            //play injuer animation.
            switch (animID)
            {
                case eStateID.eGetHit:

                    defencer.PlayAnim("Base Layer.GetHit");
                    break;
                case eStateID.eFlyAway:

                    break;
            }
        }

    }
}
