using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 属性组件，所有的属性都是需要保存的
 * 最大生命，最大魔法
 * 智力，力量等待常态数值。
 */
public class StateComponent : IStateComponent
{
    private int m_iMagic;
    private int m_iHealth;
    private float m_fMoveSpeed;
    private IPlayerStateHolder m_stateHolder;

    public int Magic
    {
        set { m_iMagic = value; }
        get { return m_iMagic; }
    }

    public int Health
    {
        set { m_iHealth = value; }
        get { return m_iHealth; }
    }

    public float MoveSpeed
    {
        set { m_fMoveSpeed = value;  }
        get { return m_fMoveSpeed; }
    }

    public StateComponent(int iMagic, int iHealth, float fMoveSpeed)
    {
        m_iMagic = iMagic;
        m_iHealth = iHealth;
        m_fMoveSpeed = fMoveSpeed;
        m_stateHolder = new PlayerStateHolder();
        m_stateHolder.SetState(new PlayerNormal());
    }
    
    public void Update()
    {
<<<<<<< HEAD
=======
        m_stateHolder.StateUpdate();
>>>>>>> 0e13a18dfa5fa281c2236b9df9f0e8d68c150740
    }
}
