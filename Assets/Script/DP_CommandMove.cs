using UnityEngine;
using UnityEditor;

// 命令模式接口,根据不同模块的功能，在这一个抽象层汇集所有需要的组件，这样在具体的实现命令借口时就能直接调用。
public abstract class AbstractMoveCommand : ICommand
{
    protected PositionComponent m_PosComponent;
    protected Vector3 m_OriginPos;

    public AbstractMoveCommand(
    PositionComponent posComponent)
    {
        m_PosComponent = posComponent;
    }

    public abstract void Execute();

    public virtual void ReCall()
    {
        m_PosComponent.SetPosition( m_OriginPos);
    }
}

// 前移命令
public class MoveForwardCommandImpl : AbstractMoveCommand
{
    public MoveForwardCommandImpl(PositionComponent posComponent):base(posComponent)
    {
    }
    
    public override void Execute()
    {
        m_PosComponent.Move(Vector3.forward);
        m_OriginPos = m_PosComponent.GetPosition(); 
    }
}

// 左移命令
public class MoveLeftCommandImpl : AbstractMoveCommand
{
    public MoveLeftCommandImpl(PositionComponent posComponent):base(posComponent)
    {
    }

    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition();
        m_PosComponent.Move(Vector3.left);
    }
}

// 右移命令
public class MoveRightCommandImpl : AbstractMoveCommand
{
    public MoveRightCommandImpl(PositionComponent posComponent):base(posComponent)
    {
    }

    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition();
        m_PosComponent.Move(Vector3.right);
    }
}

// 后移命令
public class MoveBackCommandImpl : AbstractMoveCommand
{
    public MoveBackCommandImpl(PositionComponent posComponent):base(posComponent)
    {
    }

    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition();
        m_PosComponent.Move(Vector3.back);
    }
}

// 上移命令
public class MoveUpCommandImpl : AbstractMoveCommand
{
    public MoveUpCommandImpl(PositionComponent posComponent) : base(posComponent)
    {
    }
    
    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition();
        m_PosComponent.Move(Vector3.up);
    }
}

// 上移命令
public class MoveDownCommandImpl : AbstractMoveCommand
{
    public MoveDownCommandImpl(PositionComponent posComponent) : base(posComponent)
    {
    }

    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition();
        m_PosComponent.Move(Vector3.down);
    }
}

// 跳跃命令
public class MoveJumpCommandImpl : AbstractMoveCommand
{
    public MoveJumpCommandImpl(PositionComponent posComponent) : base(posComponent)
    {
    }

    public override void Execute()
    {
        m_OriginPos = m_PosComponent.GetPosition(); 
        m_PosComponent.Jump();
    }
}