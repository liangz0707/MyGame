using System.Collections.Generic;

public abstract class IMouseControlService
{
    public abstract void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd);

    public abstract void MappingCommand(ICameraComponent postComponent);
}

public  class NullMouseControlService : IMouseControlService
{
    public override void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd) { }

    public override void MappingCommand(ICameraComponent postComponent) { }
}

public class MouseControlService : IMouseControlService
{
    Dictionary<IInputEventService.VertualKey, AbstractCameraCommand> m_Dictionary;

    public MouseControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, AbstractCameraCommand>();
    }

    public override void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd)
    {
        m_Dictionary.Add(vk, cmd);
    }

    public override void MappingCommand(ICameraComponent postComponent)
    {
        Dictionary<IInputEventService.VertualKey, AbstractCameraCommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<IInputEventService.VertualKey, AbstractCameraCommand> kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                MouseState ms = ServiceLocator.getEventSetvice().MousePos(kvp.Key);
                kvp.Value.Execute(postComponent, ms.offsetX, ms.offsetY, ms.zoomOffset, ms.X, ms.Y);
            }
        }
    }
}
