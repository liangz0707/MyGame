using System.Collections.Generic;

public abstract class IMoveControlService
{
    public abstract void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd);
    
    public abstract void MappingCommand(IMoveComponent postComponent);
}

public  class NullKeyBoardControlService : IMoveControlService
{
    public override void AddCommand(IInputEventService.VertualKey vk, AbstractMoveCommand cmd) { }

    public override void MappingCommand(IMoveComponent postComponent) { }
}

public class MoveControlService : IMoveControlService
{
    Dictionary<IInputEventService.VertualKey, AbstractMoveCommand> m_Dictionary;

    public MoveControlService()
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
            if (ServiceLocator.getInputEventSetvice().IsActive(kvp.Key))
            {
                MouseState ms = ServiceLocator.getInputEventSetvice().GetMouseState();
                kvp.Value.Execute(postComponent, ms.offsetX, ms.offsetY, ms.zoomOffset, ms.X, ms.Y);
            }
        }
    }
    
}
