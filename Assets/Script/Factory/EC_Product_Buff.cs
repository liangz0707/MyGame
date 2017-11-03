public class BuffProduct : IBuffProduct
{
    // 下面可以使用享元模式进行分离
    bool m_bHurtBuff; // 是否一次性伤害技能
    bool m_bPositiveBuff; // 是否增益buff
    bool m_bNagtiveBuff; // 是否减益buff
    bool m_bTagBuff; // 是否一般的标记buff

    int m_iTotalTime; // buff持续时间
    int m_iRemainTime; // buff剩余时间
    
    int m_iCycleTime; // 伤害或增益周期

    int m_iHurtNum; // 伤害值
    int m_iReNum; // 恢复值
    public BuffProduct()
    {

    }
    
}
