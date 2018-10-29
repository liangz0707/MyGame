using System.Collections.Generic;

public abstract class IActionControlService
{
    public abstract void MappingCommand();
    public abstract void AddCommand(IInputEventService.VertualKey vk, ACTION_ID Action);
}  

public class NullActionControlService : IActionControlService
{
    public override void MappingCommand()
    {

    }
    public override void AddCommand(IInputEventService.VertualKey vk, ACTION_ID Action)
    {

    }
}

public class ActionControlService : IActionControlService
{
    Dictionary<IInputEventService.VertualKey, ACTION_ID> m_Dictionary;
 
    public ActionControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, ACTION_ID>();
    }

    public override void MappingCommand()
    {
        Dictionary<IInputEventService.VertualKey, ACTION_ID>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<IInputEventService.VertualKey, ACTION_ID> kvp in m_Dictionary)
        {
            if (ServiceLocator.getInputEventSetvice().IsActive(kvp.Key))
            {
                ActionFactory sf = new ActionFactory();
                sf.CreateAction(kvp.Value);
            }
        }
    }

    public override void AddCommand(IInputEventService.VertualKey vk, ACTION_ID Action)
    {
        m_Dictionary.Add(vk, Action);
    }


}