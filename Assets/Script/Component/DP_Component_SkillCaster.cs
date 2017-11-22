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


    public void CreateSkill(SKILL_ID skillId)
    {
        // 创建的这个技能一开始还是属于刚刚添加，然后需要进入前摇阶段。
        // 前摇结束，进入释放阶段（一瞬间）
        // 后摇收尾阶段。

        ISkillFactory skillFactory = new SkillFactory();
        skillFactory.CreateSkill(skillId);
    }
}
