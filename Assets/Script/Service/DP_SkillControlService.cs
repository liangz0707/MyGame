using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ISkillControlService
{
    public abstract void CastSkill();
    public abstract void AddCommand(IInputEventService.VertualKey vk, ISkillFactory.SKILL_ID skill);
}  

public class NullSkillControlService : ISkillControlService
{
    public override void CastSkill()
    {

    }
    public override void AddCommand(IInputEventService.VertualKey vk, ISkillFactory.SKILL_ID skill)
    {

    }
}

public class SkillControlService : ISkillControlService
{
    Dictionary<IInputEventService.VertualKey, ISkillFactory.SKILL_ID> m_Dictionary;
 
    public override void CastSkill()
    {
        Dictionary<IInputEventService.VertualKey, ISkillFactory.SKILL_ID>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<IInputEventService.VertualKey, ISkillFactory.SKILL_ID> kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                ISkillFactory skill = new SkillFactory();
                skill.CreateSkill(kvp.Value);
            }
        }
    }

    public override void AddCommand(IInputEventService.VertualKey vk, ISkillFactory.SKILL_ID skill)
    {
        m_Dictionary.Add(vk, skill);
    }


}