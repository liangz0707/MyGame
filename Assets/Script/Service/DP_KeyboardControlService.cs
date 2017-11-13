using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class IKeyBoardControlService
{
    public abstract void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd);

    public abstract void MappingCommand();

    public abstract void AddControlComp(MoveComponent postComponent);

    public abstract void RemoveControlComp(MoveComponent postComponent);
}

public  class NullKeyBoardControlService : IKeyBoardControlService
{
    public override void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd) { }

    public override void MappingCommand() { }

    public override void AddControlComp(MoveComponent postComponent) { }

    public override void RemoveControlComp(MoveComponent postComponent) { }
}

public class KeyBoardControlService : IKeyBoardControlService
{
    Dictionary<IInputEventService.VertualKey, AbstractMoveCommand> m_Dictionary;
    List<MoveComponent> m_ControlList;  // 保存所有需要被控制的对象。

    public KeyBoardControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, AbstractMoveCommand>();
        m_ControlList = new List<MoveComponent>();
    }

    public override void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd)
    {
        m_Dictionary.Add(vk, cmd);
    }
    
    public override void MappingCommand()
    {
        Dictionary< IInputEventService.VertualKey, AbstractMoveCommand >.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair< IInputEventService.VertualKey, AbstractMoveCommand > kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                MouseState ms = ServiceLocator.getEventSetvice().MousePos(kvp.Key);
                foreach (MoveComponent posComponent in m_ControlList)
                    kvp.Value.Execute(posComponent, ms.offsetX, ms.offsetY, ms.zoomOffset, ms.X, ms.Y);
            }
        }
    }

    public override void AddControlComp(MoveComponent postComponent)
    {
        if (m_ControlList.Contains(postComponent)) return;
        m_ControlList.Add(postComponent);
    }

    public override void RemoveControlComp(MoveComponent postComponent)
    {
        m_ControlList.Remove(postComponent);
    }
}
