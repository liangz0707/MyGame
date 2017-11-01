using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CMoveInputController
{
    Dictionary<string, AbstractMoveCommand> m_Dictionary;
    public CMoveInputController()
    {
        m_Dictionary = new Dictionary<string, AbstractMoveCommand>();
    }

    public void AddCommand(string chr, AbstractMoveCommand cmd)
    {
        m_Dictionary.Add(chr, cmd);
    }

    //Translate移动控制函数,需要判断始终的按键状态：GetKey
    public void MoveControlByTranslate(MoveComponent posComponent)
    {
        Dictionary<string, AbstractMoveCommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<string, AbstractMoveCommand> kvp in m_Dictionary)
        {
            if (Input.GetKey(kvp.Key))
            {
                kvp.Value.Execute(posComponent);
            }
        }
    }
}
