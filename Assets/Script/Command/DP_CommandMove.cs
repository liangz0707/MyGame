﻿using UnityEngine;
using UnityEditor;

// 命令模式接口,根据不同模块的功能，在这一个抽象层汇集所有需要的组件，这样在具体的实现命令借口时就能直接调用。
public abstract class AbstractMoveCommand 
{
    public abstract void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y);
}

// 前移命令
public class MoveForwardCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveForward(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 左移命令
public class MoveLeftCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveLeft(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 右移命令
public class MoveRightCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveRight(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 后移命令
public class MoveBackCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveBack(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 上移命令
public class MoveUpCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveUp(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 上移命令
public class MoveDownCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.MoveDown(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}

// 跳跃命令
public class MoveJumpCommandImpl : AbstractMoveCommand
{
    public override void Execute(IMoveComponent posComponent, float xOffset, float yOffset, float zoomOffset, float x, float y)
    {
        posComponent.Jump(ref ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData);
    }
}