using System;
using UnityEngine;

public class EC_SceneStateController : AbstractStateController
{
    public IState m_IState;

    public override void SetState(IState State)
    {
        m_IState = State;
    }

    public override void StateUpdate()
    {
        m_IState.StateUpdate();
    }
}

public class StartSceneState : AbstractSceneState
{
    public override void StateUpdate()
    {
        m_StateController.SetState(new ASceneState());
    }
}

public class ASceneState : AbstractSceneState
{
    public override void StateUpdate()
    {
        throw new NotImplementedException();
    }
}

public class BSceneState : AbstractSceneState
{

    public override void StateUpdate()
    {
    }
}   

/* *
 * 将接口转换成实现类:
 * 1. 因为状态针对不同的内容有好多种
 * 2. 先转换成抽象类可以定义很多子状态公用方法，参数
 * */
public abstract class AbstractSceneState : IState
{
    public EC_SceneStateController m_StateController
    {
        get
        {
            return m_StateController;
        }
        set
        {
        }
    }

    public abstract void StateUpdate();
}