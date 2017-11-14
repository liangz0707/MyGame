using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 现在的问题是如何让buff去处理角色的状态，通过设置标记？
public class BuffComponent : IBuffComponent
{
    private List<IBuffProduct> m_buffs;

    public BuffComponent()
    {
        m_buffs = new List<IBuffProduct>();
    }

    public void AddBuff(IBuffProduct buff)
    {
        if(buff.BeforeAttached(m_buffs))
        {
            m_buffs.Add(buff);
            buff.AfterAttached(m_buffs);
        }
    }

    // 循环便利角色身上的所有buff进行触发，和逻辑操作。所有类型buff之间的交互。
    public void Update()
    {
        foreach(IBuffProduct buff in m_buffs)
        {
            if (buff.Update(m_buffs))
            {
                if (buff.BeforeRemove(m_buffs))
                {
                    m_buffs.Remove(buff);
                    buff.AfterRemove(m_buffs);
                }
            }
        }
    }

    public void UpdateState(PlayerProduct player)
    {
        foreach (IBuffProduct buff in m_buffs)
        {
            buff.Update(player);
        }
    }
}

