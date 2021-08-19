using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AttTypeDefine{
    public delegate void NotifySkill();

    public enum eSkillBlindType
    {
        eEffectWorld,
        eEffectOwner,
        eDamageOwner,
    }
    public enum eTrigType
    {
        eAuto = 0,
        eCondition,
    };
    public enum eTrigSkillState
    {
        eTrigBegin,
        eTrigEnd,
    };
    
    public enum eSkillType
    {
        eAttack = 0,
        eSkill1
    };

    public enum ePlayerSide
    {
        ePlayer,
        eEnemy,
        eNPC,
    }

    public enum eStateID
    {
        eNull = -1,
        eGetHit,// ‹…À
        eFlyAway,//ª˜∑…
    }

    public enum ePlayerAttr
    {
        eNull = -1,
        eHP = 0,
        eAttack = 1,
        eSize = 2
    }

    public class GameEvent : UnityEvent { };
    public class GameBtnEvent : UnityEvent<PointerEventData> { };
}