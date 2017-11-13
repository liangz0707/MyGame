using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 角色状态组件，控制角色生命，魔法，
 * 在游戏中会变化的状态。
 */
public class StateComponent
{
    private int m_iHealth;
    private int m_iMagic;
    private int m_iShield;
    private float m_fMoveSpeed;

    public int Health //生命
    {
        get { return m_iHealth; }
        set { m_iHealth = value; }
    }
    public int Magic  //魔法
    {
        get { return m_iMagic; }
        set { m_iMagic = value; }
    }
    public int Shield //护盾
    {
        get { return m_iShield; }
        set { m_iShield = value; }
    }

    public float MoveSpeed //护盾
    {
        get { return m_fMoveSpeed; }
        set { m_fMoveSpeed = value; }
    }

    public StateComponent(int Health, int iMagic)
    {
        m_iHealth = Health;
        m_iMagic = iMagic;
        m_iShield = 0;
        m_fMoveSpeed = 5.0f;
    }

    public StateComponent(int Health, int iMagic ,float MoveSpeed)
    {
        m_iHealth = Health;
        m_iMagic = iMagic;
        m_iShield = 0;
        m_fMoveSpeed = MoveSpeed;
    }

}
