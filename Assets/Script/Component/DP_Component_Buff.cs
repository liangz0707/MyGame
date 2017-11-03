using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BuffComponent
{
    private List<IBuffProduct> m_buffs;

    public BuffComponent(List<IBuffProduct> buffs)
    {
        m_buffs = buffs;
    }

    public void AddBuff(IBuffProduct buff)
    {
        m_buffs.Add(buff);
    }

    public void Update()
    {

    }

}

