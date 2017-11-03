/* *
 * 现在实现的是技能控制器，对于技能实现的思路是，把技能分成：Buff 和 Skill，
 * Buff是附加在角色身上的  ，这里就可以使用享元模式：buff有固定的属性，也有需要更改的属性。
 * Skill是独立的对象，这样Skill的控制就十分灵活， 用Skill去控制buff，转而通过buff去影响角色，这样技能就和角色独立开了。
 * 
 * 举个例子，Skill对角色造成伤害，则给角色附加一个buff，这个buff是立即发动，并且造成伤害，那么伤害削减和伤害抵消，就只要通过buff之间的判断就可以
 * Skill 是可以看到，但是无法拾取，会影响玩家的。
 * 
 * 
 * 技能需要通过工厂方法建造么？释放技能传入ID，不同类型的技能用不同的工厂方法建造。然后技能给角色施加伤害，然后独立的播放声音特效？
 * 那么buff也需要工厂么？  需要！但是应该不需要管理器，而是构造完成之后直接交给角色管理。
 * 
 * 所以现在需要首先实现的是buff系统。
 * 
 * 角色Update时 只更新buff状态
 * */
using System.Collections.Generic;

public class SkillManager
{
    List<ISkillProduct> m_skills;

    public SkillManager()
    {
        m_skills = new List<ISkillProduct>();
    }
    public void AddPlayer(ISkillProduct skill)
    {
        m_skills.Add(skill);
    }

    public void RemoveShape(ISkillProduct skill)
    {
        m_skills.Remove(skill);
    }

    public void ClearSkills()
    {
        m_skills.Clear();
    }

    public void Update()
    {
        foreach (ISkillProduct skill in m_skills)
        {
            // 根据技能类型 搜索地图，获取角色

            // 将技能存储的buff 放在角色身上。
              
            //  ** 放在角色身上这个过程就是通过工厂模式  调用需要的buff工厂并且把角色传进去
                skill.Update();
            // 移除技能
        }
    }
}

