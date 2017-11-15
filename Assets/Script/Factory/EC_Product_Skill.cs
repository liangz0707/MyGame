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
    PlayerProduct m_player;
    public SkillProduct1(PlayerProduct player)
    {
        m_player = player;
    }

    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct2 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_2;
    PlayerProduct m_player;
    public SkillProduct2(PlayerProduct player)
    {
        m_player = player;
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
    PlayerProduct m_player;
    public SkillProduct3(PlayerProduct player)
    {
        m_player = player;
    }
    public override bool Update()
    {
        IBuffFactory buffFactory = new BuffFactory();
        buffFactory.CreateImtHurtBuff(m_player);
        return true;
    }
}

public class SkillProduct4 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_4;
    PlayerProduct m_player;
    public SkillProduct4(PlayerProduct player)
    {
        m_player = player;
    }
    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct5 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_5;
    PlayerProduct m_player;
    public SkillProduct5(PlayerProduct player)
    {
        m_player = player;
    }
    public override bool Update()
    {
        return true;
    }
}

public class SkillProduct6 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_6;
    PlayerProduct m_player;
    public SkillProduct6(PlayerProduct player)
    {
        m_player = player;
    }
    public override bool Update()
    {
        return true;
    }
}

