using UnityEngine;
using AttTypeDefine;

public class BasePlayer : MonoBehaviour
{
    [HideInInspector]
    public Vector3 closestHitPoint;

    public Vector2[] animAttackPerArray;
    public Vector2[] animSkillPerArray;

    public ePlayerSide playerSide;

    protected Animator _Anim;
    public Animator Anim => (_Anim);

    protected int typeId;
    public int typeID => (typeId);

    protected virtual void Start()
    {
        _Anim = GetComponent<Animator>();
    }
}
