using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class IMouseControlService
{
    public abstract void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd);

    public abstract void MappingCommand();

    public abstract void SetControlComp(CameraComponent postComponent);

    public abstract void RemoveControlComp();
}

public  class NullMouseControlService : IMouseControlService
{
    public override void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd) { }

    public override void MappingCommand() { }

    public override void SetControlComp(CameraComponent postComponent) { }

    public override void RemoveControlComp() { }

}

public class MouseControlService : IMouseControlService
{
    Dictionary<IInputEventService.VertualKey, AbstractCameraCommand> m_Dictionary;
    CameraComponent m_ControlComp;  // 保存所有需要被控制的对象。

    public MouseControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, AbstractCameraCommand>();
        m_ControlComp = null;
    }

    public override void AddCommand(IInputEventService.VertualKey vk, AbstractCameraCommand cmd)
    {
        m_Dictionary.Add(vk, cmd);
    }
    
    public override void MappingCommand()
    {
        if (m_ControlComp == null) return;
        Dictionary< IInputEventService.VertualKey, AbstractCameraCommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair< IInputEventService.VertualKey, AbstractCameraCommand> kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                MouseState ms = ServiceLocator.getEventSetvice().MousePos(kvp.Key); 
                kvp.Value.Execute(m_ControlComp,ms.offsetX,ms.offsetY, ms.zoomOffset, ms.X, ms.Y);
            }
        }
    }

    public override void SetControlComp(CameraComponent postComponent) {
        m_ControlComp = postComponent;
    }

    public override void RemoveControlComp() {
        m_ControlComp = null;
    }
}
