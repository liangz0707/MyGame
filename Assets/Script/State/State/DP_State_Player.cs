using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum PlAYER_STATE
{
    NORMAL,
    MOVE,
    JUMP,
    ATTACKED,
    ATTACK_BEFORE,
    ATTACK_AFTER,
    SKILL_BEFORE,
    SKILL_AFTER,
    ON_VEHICLE,
    ON_RIDING,

    DEAD,
}

public abstract class IPlayerState
{
    protected IPlayerStateHolder m_player;

    public abstract int GetPlayerState();
    public virtual void SetHolder(IPlayerStateHolder player)
    {
        m_player = player;
    }

    // 状态开始前做什么
    public virtual void Begin()
    {

    }

    // 状态结束时做什么：例如如果技能释放前摇结束，则需要停止，特效和动作
    public virtual bool Stop()
    {
        return true;  // 表示是否成功停止。
    }

    // 状态更新时做什么
    public virtual void Update()
    {

    }
    
}

public class PlayerAttacked : IPlayerState
{

    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.ATTACKED;
    }

}

public class PlayerNormal : IPlayerState
{

    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.NORMAL;
    }

}

public class PlayerStateMove : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.MOVE;
    }
}

public class PlayerStateJump : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.JUMP;
    }
    
}

// 攻击前摇
public class PlayerStateAttackBefore : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.ATTACK_BEFORE;
    }
}

// 攻击后摇
public class PlayerStateAttackAfter : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.ATTACK_AFTER;
    }

}

// 技能前摇
public class PlayerStateCastSkillBefore : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.SKILL_BEFORE;
    }
        
}

// 技能后摇
public class PlayerStateCastSkillAfter : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.SKILL_AFTER;
    }
}

public class PlayerStateDead : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.DEAD;
    }
}

// 驾驶，坐骑
public class PlayerStateRiding : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.ON_RIDING;
    }

}

// 在载具上 跟随移动
public class PlayerStateOnVehicle : IPlayerState
{
    public override int GetPlayerState()
    {
        return (int)PlAYER_STATE.ON_VEHICLE;
    }
}