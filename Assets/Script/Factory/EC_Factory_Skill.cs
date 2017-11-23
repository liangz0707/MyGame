using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SkillFactory : ISkillFactory
{

    public override ISkillProduct CreateSkill(SKILL_ID id)
    {
        ISkillCasterComponent caster = ControllerCenter.Instance.GetMainPlayer().GetSkillCaster();
        ISkillProduct skill = null;
        switch (id)
        {
            case SKILL_ID.SKILL_1: skill = new SkillProduct1(caster); break;
            case SKILL_ID.SKILL_2: skill = new SkillProduct2(caster); break;
            case SKILL_ID.SKILL_3: skill = new SkillProduct3(caster); break;
            case SKILL_ID.SKILL_4: skill = new SkillProduct4(caster); break;
            case SKILL_ID.SKILL_5: skill = new SkillProduct5(caster); break;
            case SKILL_ID.SKILL_6: skill = new SkillProduct6(caster); break;
            default: skill = new NullSkillProduct(); break;
        }
        ControllerCenter.Instance.AddSkill(skill);
        return skill;
    }

    public override ISkillProduct CreateSkill(ISkillCasterComponent caster, SKILL_ID id)
    {
        // 需要根据技能的id ，搜索技能的目标。
        // 释放技能的时候，把技能的目标，放到caster当中。 
        ISkillProduct skill = null;
        switch (id)
        {
            case SKILL_ID.SKILL_1: skill = new SkillProduct1(caster); break;
            case SKILL_ID.SKILL_2: skill = new SkillProduct2(caster); break;
            case SKILL_ID.SKILL_3: skill = new SkillProduct3(caster); break;
            case SKILL_ID.SKILL_4: skill = new SkillProduct4(caster); break;
            case SKILL_ID.SKILL_5: skill = new SkillProduct5(caster); break;
            case SKILL_ID.SKILL_6: skill = new SkillProduct6(caster); break;
            default: skill = new NullSkillProduct(); break;
        }
        ControllerCenter.Instance.AddSkill(skill);
        return skill;
    }

    public override ISkillProduct CreateAOESkill(SKILL_ID id)
    {
        throw new NotImplementedException();
    }

    public override ISkillProduct CreateDirectionSkil(SKILL_ID id)
    {
        throw new NotImplementedException();
    }

    public override ISkillProduct CreatePersonSkill(SKILL_ID id)
    {
        throw new NotImplementedException();
    }

    public override ISkillProduct CreatePointSkill(SKILL_ID id)
    {
        throw new NotImplementedException();
    }

    public override ISkillProduct CreateTeamSkil(SKILL_ID id)
    {
        throw new NotImplementedException();
    }
}

