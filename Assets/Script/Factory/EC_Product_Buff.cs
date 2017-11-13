using System.Collections.Generic;

/*
 * 
 * 一个buff的实例：
 * buff和角色之间的关系  
 * buff之间的关系
 * 
 * */
public class BuffProduct : IBuffProduct
{
    // 下面可以使用享元模式进行分离？每个buff都是不同的 应该用不到，不存在公共部分
    bool m_bHurtBuff; // 是否一次性伤害技能
    bool m_bPositiveBuff; // 是否增益buff
    bool m_bNagtiveBuff; // 是否减益buff
    bool m_bTagBuff; // 是否一般的标记buff
    bool m_bFourceMoveBuff; // 是否强制移动buff
    bool m_bFreezeBuff; // 是否禁锢buff

    int m_iTotalTime; // buff持续时间
    int m_iRemainTime; // buff剩余时间
    
    int m_iCycleTime; // 伤害或增益周期

    int m_iHurtNum; // 伤害值
    int m_iReNum; // 恢复值
    public BuffProduct()
    {

    }

    public override bool AfterAttached(List<IBuffProduct> lBuffs)
    {
        return true;
    }

    public override bool AfterRemove(List<IBuffProduct> lBuffs)
    {
        return true;
    }

    public override bool BeforeAttached(List<IBuffProduct> lBuffs)
    {
        return true;
    }

    public override bool BeforeRemove(List<IBuffProduct> lBuffs)
    {
        return true;
    }

    public override bool Update(List<IBuffProduct> lBuffs)
    {
        return true;
    }

    public override bool Update(PlayerProduct player)
    {
        return true;
    }
}
