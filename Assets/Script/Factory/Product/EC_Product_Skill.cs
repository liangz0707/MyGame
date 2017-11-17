using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

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
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct1(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill1"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if(!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

public class SkillProduct2 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_2;
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct2(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill2_FlameThrower"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if (!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

public class SkillProduct3 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_3;
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct3(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill3_GazFire"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if (!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

public class SkillProduct4 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_4;
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct4(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill4_GazFireBig"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if (!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

public class SkillProduct5 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_5;
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct5(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill5_Nuke"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if (!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

public class SkillProduct6 : ISkillProduct
{
    static SKILL_ID SkillID = SKILL_ID.SKILL_6;
    ISkillCasterComponent m_caster;
    GameObject m_ps;
    public SkillProduct6(ISkillCasterComponent caster)
    {
        m_caster = caster;
        caster.GetPosition();
        m_ps = UnityEngine.Object.Instantiate((GameObject)Resources.Load("SkillPartical/Skill6_SmokeGrenade"));
        m_ps.transform.position = caster.GetPosition();
        m_ps.GetComponent<ParticleSystem>().Play();
        m_ps.GetComponent<ParticleSystem>().loop = false;
    }

    public override bool Update()
    {
        if (!m_ps.GetComponent<ParticleSystem>().isPlaying)
        {
            UnityEngine.Object.DestroyObject(m_ps);
            return true;
        }
        else
        {
            m_ps.transform.position = m_caster.GetPosition();
        }
        return false;
    }
}

