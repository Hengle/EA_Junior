using UnityEngine;
using AttTypeDefine;
using System.Collections.Generic;

public class SEActionDamage_BindOwner : SEAction_BaseAction
{
    public SEAction_TrigBuff trigBuffInst;

    [HideInInspector]
    public string socketName;
    [HideInInspector]
    public Vector3 offSet;
    [HideInInspector]
    public Vector3 offRot;

    GameObject owner;

    bool isTriggered = false;

    BoxCollider bc;
    Animator anim;

    float startColliderPer;
    float endColliderPer;

    BasePlayer bp;

    //���������б�
    List<BasePlayer> baList;

    private void Awake()
    {
        baList = new List<BasePlayer>();
    }

    public override void TrigAction()
    {
        base.TrigAction();

        var ds = GetDataStore();
        if(ds == null)
        {
            Debug.LogError("Error Logic");
            return;
        }
        owner = ds.owner;
        bc = GetComponent<BoxCollider>();
        owner = ds.owner;
        anim = owner.GetComponent<Animator>();
        if(null == anim)
        {
            Debug.Log("Error Logic");
            return;
        }

        //��ȡ�ҽӵ�
        var socket = GlobalHelper.FindGoByName(owner, socketName);
        if (null == socket)
        {
            socket = owner;
        }
        transform.parent = socket.transform;
        transform.localPosition = offSet;
        transform.localRotation = Quaternion.Euler(offRot);


        bp = owner.GetComponent<BasePlayer>();

        var skillName = int.Parse(ds.skillInfo.name);

        var index = skillName - bp.typeID;


        if(index < 10)
        {
            startColliderPer = bp.animAttackPerArray[index - 1].x;
            endColliderPer = bp.animAttackPerArray[index - 1].y;
        }
        else//����
        {
            startColliderPer = bp.animSkillPerArray[index - 1].x;
            endColliderPer = bp.animSkillPerArray[index - 1].y;
        }

        isTriggered = true;
    }
    AnimatorStateInfo asi;

    float curPer;
    float lastPer;

    protected override void Update()
    {
        base.Update();
        if (!isTriggered) return;
        //�Ա������ߴ��� 
        if (baList.Count > 0)
        {
            var ba = baList[0];
            baList.Remove(ba);
            Debug.Log("Success: Trig Buff");
            var ds = GetDataStore();
            ds.target = ba.gameObject;
            trigBuffInst.OnStart();
           // return;//���ֻ���һ�ξ�return ��������ÿ����ֶ����ж�
            //TrigBuff->ʵ����Buff

        }

        //�ж��Ƿ�Ҫ������ײ��->������
        asi = anim.GetCurrentAnimatorStateInfo(0);

        curPer = asi.normalizedTime % 1.0f;
        if (curPer >= startColliderPer && lastPer < startColliderPer)
        {
            bc.enabled = true;
        }
        else if (curPer > endColliderPer && lastPer <= endColliderPer)
        {
            bc.enabled = false;
        }
        lastPer = curPer;

    }

    private void OnTriggerEnter(Collider other)
    {
        BasePlayer ba = other.gameObject.GetComponent<BasePlayer>();
        if(null == ba)
        {
            return;
        }
        else
        {
            //��Ӫ����
            var attacker = bp;
            var defenser = ba;


            if (bp.playerSide == ePlayerSide.eEnemy && ba.playerSide == ePlayerSide.ePlayer
                || bp.playerSide == ePlayerSide.ePlayer && ba.playerSide == ePlayerSide.eEnemy)
            {
                //valid trigger
                baList.Add(ba);
                var dir = (attacker.transform.position - defenser.transform.position).normalized;
                var closedPoint = other.bounds.center + dir * other.bounds.extents.z;//��ײ�������ĵ�//other.ClosestPoint(other.gameObject.transform.position);
                defenser.closestHitPoint = closedPoint;
            }
        }
    }
}
