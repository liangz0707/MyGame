using System.Collections.Generic;

public abstract class IKeyBoardControlService
{
    public abstract void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd);
    
    public abstract void MappingCommand(IMoveComponent postComponent);
}

public  class NullKeyBoardControlService : IKeyBoardControlService
{
    public override void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd) { }

    public override void MappingCommand(IMoveComponent postComponent) { }
}

public class KeyBoardControlService : IKeyBoardControlService
{
    Dictionary<IInputEventService.VertualKey, AbstractMoveCommand> m_Dictionary;

    public KeyBoardControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, AbstractMoveCommand>();
    }

    public override void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd)
    {
        m_Dictionary.Add(vk, cmd);
    }

    public override void MappingCommand(IMoveComponent postComponent)
    {
        Dictionary<IInputEventService.VertualKey, AbstractMoveCommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<IInputEventService.VertualKey, AbstractMoveCommand> kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                MouseState ms = ServiceLocator.getEventSetvice().MousePos(kvp.Key);
                kvp.Value.Execute(postComponent, ms.offsetX, ms.offsetY, ms.zoomOffset, ms.X, ms.Y);
            }
        }
    }
    
}
