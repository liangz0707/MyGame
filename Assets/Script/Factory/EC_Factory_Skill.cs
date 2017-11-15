using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SkillFactory : ISkillFactory
{

    public override ISkillProduct CreateSkill(SKILL_ID id)
    {
        PlayerProduct player = ControllerCenter.Instance.GetMainPlayer();
        ISkillProduct skill = null;
        switch (id)
        {
            case SKILL_ID.SKILL_1: skill = new SkillProduct1(player); break;
            case SKILL_ID.SKILL_2: skill = new SkillProduct2(player); break;
            case SKILL_ID.SKILL_3: skill = new SkillProduct3(player); break;
            case SKILL_ID.SKILL_4: skill = new SkillProduct4(player); break;
            case SKILL_ID.SKILL_5: skill = new SkillProduct5(player); break;
            case SKILL_ID.SKILL_6: skill = new SkillProduct6(player); break;
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

