using UnityEngine;
using AttTypeDefine;
using com.dxz.config;

public class BaseAttributes : MonoBehaviour
{
    //hp,attack
    int[] attrs;
    BGE_PlayerTemplate playerTpl;
    BGE_PlayerAttTemplate playerAttTpl;

    private void Awake()
    {
        attrs = new int[(int)ePlayerAttr.eSize];
    }

    private void Start()
    {

    }

    //建立表格

    //填写表格数据

    //读取表格数据

    //将表格数据赋值给BaseAttributes的成员变量们

    //初始化角色的基础信息

    public void InitPlayerAttr(string name)
    {
        playerTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerTemplate>("PlayerTemplate",name);
        playerAttTpl = GlobalHelper.GetTheEntityByName<BGE_PlayerAttTemplate>("PlayerAttTemplate", name);

        this[ePlayerAttr.eAttack] = playerAttTpl.f_Attack;
        this[ePlayerAttr.eHP] = playerAttTpl.f_HP;

    }
    //索引器  只读
    public int this[ePlayerAttr att]
    {
        get
        {
            if (att <= ePlayerAttr.eNull)
                return -1;
            return attrs[(int)att]; 
        }
        set
        {
            if (att <= ePlayerAttr.eNull)
            {
                Debug.LogError("Logic Error:" + att);
                return;
            }
            if (value != attrs[(int)att])
                attrs[(int)att] = value;
        }
    }
}
