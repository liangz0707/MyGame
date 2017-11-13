using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SkillFactory : ISkillFactory
{

    public override ISkillProduct CreateSkill(SKILL_ID id)
    {
        //判断技能类型进入不同的子方法：
        /*
        switch ()
        {
            case ISkillFactory.TY1:

        }*/
        ISkillProduct skill = null; // 配置一些状态。
        ControllerCenter.Instance.AddSkill(skill);
        return null;
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

