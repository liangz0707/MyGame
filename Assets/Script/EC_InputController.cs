using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CMoveInputController
{
    Dictionary<string, ICommand> m_Dictionary;
    public CMoveInputController()
    {
        m_Dictionary = new Dictionary<string, ICommand>();
    }

    public void AddCommand(string chr, ICommand cmd)
    {
        m_Dictionary.Add(chr, cmd);
    }

    //Translate移动控制函数,需要判断始终的按键状态：GetKey
    public void MoveControlByTranslate()
    {
        Dictionary<string, ICommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<string, ICommand> kvp in m_Dictionary)
        {
            if (Input.GetKey(kvp.Key))
            {
                kvp.Value.Execute();
            }
        }
    }
}

public class CSkillInputController
{
    Dictionary<string, ICommand> m_Dictionary;
    public CSkillInputController()
    {
        m_Dictionary = new Dictionary<string, ICommand>();
    }

    public void AddCommand(string chr, ICommand cmd)
    {
        m_Dictionary.Add(chr, cmd);
    }

    //Translate技能的控制状态，需要判断何时按下
    public void SkillControlByTranslate()
    {
        Dictionary<string, ICommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<string, ICommand> kvp in m_Dictionary)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                kvp.Value.Execute();
            }
        }
    }
}