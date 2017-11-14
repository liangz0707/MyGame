﻿using System.Collections.Generic;

public abstract class ISkillControlService
{
    public abstract void MappingCommand(ISkillComponent skillComponent);
    public abstract void AddCommand(IInputEventService.VertualKey vk, SKILL_ID skill);
}  

public class NullSkillControlService : ISkillControlService
{
    public override void MappingCommand(ISkillComponent skillComponent)
    {

    }
    public override void AddCommand(IInputEventService.VertualKey vk, SKILL_ID skill)
    {

    }
}

public class SkillControlService : ISkillControlService
{
    Dictionary<IInputEventService.VertualKey, SKILL_ID> m_Dictionary;
 
    public SkillControlService()
    {
        m_Dictionary = new Dictionary<IInputEventService.VertualKey, SKILL_ID>();
    }

    public override void MappingCommand(ISkillComponent skillComponent)
    {
        Dictionary<IInputEventService.VertualKey, SKILL_ID>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<IInputEventService.VertualKey, SKILL_ID> kvp in m_Dictionary)
        {
            if (ServiceLocator.getEventSetvice().IsActive(kvp.Key))
            {
                ISkillFactory skillFactory = new SkillFactory();
                skillFactory.CreateSkill(kvp.Value, skillComponent);
            }
        }
    }

    public override void AddCommand(IInputEventService.VertualKey vk, SKILL_ID skill)
    {
        m_Dictionary.Add(vk, skill);
    }


}