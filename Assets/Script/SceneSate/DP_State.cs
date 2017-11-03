using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* *
 * 这个实现的是状态模式的框架，可以应用到角色状态，NPC状态，AI状态等
 * */
public abstract class AbstractStateController
{
    IState m_IState;
    public virtual void StateUpdate()
    {
        m_IState.StateUpdate();
    }

    public virtual void SetState(IState state)
    {
        m_IState = state;
    }
}

public interface IState
{
    void StateUpdate();
}