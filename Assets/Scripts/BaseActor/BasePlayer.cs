using UnityEngine;
using AttTypeDefine;

public class BasePlayer : MonoBehaviour
{
    public string playerName;
    //hp,attack
    BaseAttributes _BaseAttr;
    public BaseAttributes BaseAttr => (_BaseAttr);

    [HideInInspector]
    public Vector3 closestHitPoint;

    public Vector2[] animAttackPerArray;
    public Vector2[] animSkillPerArray;

    public ePlayerSide playerSide;

    protected Animator _Anim;
    public Animator Anim => (_Anim);

    protected int typeId;
    public int typeID => (typeId);

    protected virtual void Awake()
    {
        _BaseAttr = gameObject.AddComponent<BaseAttributes>();
    }

    protected virtual void Start()
    {
        _Anim = GetComponent<Animator>();
        _BaseAttr.InitPlayerAttr(playerName);
    }

    public void PlayAnim(string animName)
    {
        _Anim.SetTrigger(animName);
    }
}
