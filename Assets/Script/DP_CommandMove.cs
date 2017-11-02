using UnityEngine;
using UnityEditor;

// 命令模式接口,根据不同模块的功能，在这一个抽象层汇集所有需要的组件，这样在具体的实现命令借口时就能直接调用。
public abstract class AbstractMoveCommand 
{
    public abstract void Execute(MoveComponent posComponent);

    public abstract void Revoke(MoveComponent posComponent);
}

// 前移命令
public class MoveForwardCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveForward();
    }

    public override void Revoke(MoveComponent posComponent){
        posComponent.MoveBack();
    }
}

// 左移命令
public class MoveLeftCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveLeft();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.MoveRight();
    }
}

// 右移命令
public class MoveRightCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveRight();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.MoveLeft();
    }
}

// 后移命令
public class MoveBackCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveBack();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.MoveForward();
    }
}

// 上移命令
public class MoveUpCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveUp();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.MoveDown();
    }
}

// 上移命令
public class MoveDownCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.MoveDown();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.MoveUp();
    }
}

// 跳跃命令
public class MoveJumpCommandImpl : AbstractMoveCommand
{
    public override void Execute(MoveComponent posComponent)
    {
        posComponent.Jump();
    }

    public override void Revoke(MoveComponent posComponent)
    {
        posComponent.Jump();
    }
}