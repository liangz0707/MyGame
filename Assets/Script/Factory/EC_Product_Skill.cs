using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum SKILL_ID
{
    SKILL_NULL,
    SKILL_1,
    SKILL_2,
    SKILL_3,
    SKILL_4,
    SKILL_5,
    SKILL_6,
    SKILL_NUM,
}

public class NullSkillProduct : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_NULL;
    public NullSkillProduct()
    {
    }

    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct1 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_1;
    ISkillComponent c_skillComponent;
    public SkillProduct1(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }

    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct2 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_2;
    ISkillComponent c_skillComponent;
    public SkillProduct2(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }

    public override bool Update()
    {
        // 1.使用搜索服务搜索技能范围内的目标
        // playerList

        // 给目标添加buff，设置结束标记

        // 2.播放一个动画，播放完成，使用搜索服务搜索技能范围内的目标，产生特效

        // 给目标添加buff，设置结束标记
        return true;
    }
}

public class SkillProduct3 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_3;
    ISkillComponent c_skillComponent;
    public SkillProduct3(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }
    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct4 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_4;
    ISkillComponent c_skillComponent;
    public SkillProduct4(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }
    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct5 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_5;
    ISkillComponent c_skillComponent;
    public SkillProduct5(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }
    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct6 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_6;
    ISkillComponent c_skillComponent;
    public SkillProduct6(ISkillComponent skillComponent)
    {
        c_skillComponent = skillComponent;
    }
    public override bool Update()
    {
        return true;
    }
}

