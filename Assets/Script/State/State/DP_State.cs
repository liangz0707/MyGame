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
    ACTION_BEFORE,
    ACTION_AFTER,
    ON_VEHICLE,
    ON_RIDING,

    DEAD,
}

public abstract class IState<T>
{
    protected T state;

    public abstract IState<T> HandleState(StateHolder<T> holder, IState<T> state);

    public virtual T GetState()
    {
        return state;
    }
}

// 
public class PlayerNormalState : IState<PlAYER_STATE>
{
    private PlayerNormalState()
    {
        state = PlAYER_STATE.NORMAL;
    }
    static private PlayerNormalState s;
    public static PlayerNormalState STATE()
    {
        if (s == null)
            s = new PlayerNormalState();
        return s;
    }
    public override IState<PlAYER_STATE> HandleState(StateHolder<PlAYER_STATE> holder, IState<PlAYER_STATE> state)
    {
        switch (state.GetState())
        {
            case PlAYER_STATE.MOVE:
            case PlAYER_STATE.ATTACKED:
            case PlAYER_STATE.ATTACK_AFTER:
            case PlAYER_STATE.ATTACK_BEFORE:
            case PlAYER_STATE.DEAD:
                return state;
        }
        return null;
    }

}
