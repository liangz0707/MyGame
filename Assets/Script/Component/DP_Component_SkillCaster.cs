using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SkillCasterComponent : ISkillCasterComponent
{
    Vector3 m_vPos;
    Transform m_Transform;
    public SkillCasterComponent(Vector3 pos)
    {
        m_vPos = pos;
    }

    public SkillCasterComponent(Transform trans)
    {
        m_Transform = trans;
    }


    public ISkillCasterComponent GetAims()
    {
        throw new NotImplementedException();
    }

    public Vector3 GetPosition()
    {
        if (m_Transform != null)
        {
            return m_Transform.position;
        }
        else
        {

            return m_vPos;
        }
    }

    public void SetAim()
    {
        throw new NotImplementedException();
    }
}
