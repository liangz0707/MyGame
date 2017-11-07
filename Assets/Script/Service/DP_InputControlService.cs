using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class IInputControlService
{
    public abstract void AddCommand(string chr, AbstractMoveCommand cmd);

    public abstract void TransLateInput();

    public abstract void AddControlComp(MoveComponent postComponent);

    public abstract void RemoveControlComp(MoveComponent postComponent);
}

public  class NullInputConrtolService: IInputControlService
{
    public override void AddCommand(string chr, AbstractMoveCommand cmd) { }

    public override void TransLateInput() { }

    public override void AddControlComp(MoveComponent postComponent) { }

    public override void RemoveControlComp(MoveComponent postComponent) { }
}

public class InputControlService : IInputControlService
{
    Dictionary<string, AbstractMoveCommand> m_Dictionary;
    List<MoveComponent> m_ControlList;  // 保存所有需要被控制的对象。

    public InputControlService()
    {
        m_Dictionary = new Dictionary<string, AbstractMoveCommand>();
        m_ControlList = new List<MoveComponent>();
    }

    public override void AddCommand(string chr, AbstractMoveCommand cmd)
    {
        m_Dictionary.Add(chr, cmd);
    }
    
    public override void TransLateInput()
    {
        Dictionary<string, AbstractMoveCommand>.KeyCollection keyCol = m_Dictionary.Keys;
        foreach (KeyValuePair<string, AbstractMoveCommand> kvp in m_Dictionary)
        {
            if (Input.GetKey(kvp.Key))
            {
                foreach(MoveComponent posComponent in m_ControlList)
                    kvp.Value.Execute(posComponent);
            }
        }
    }

    public override void AddControlComp(MoveComponent postComponent)
    {
        m_ControlList.Add(postComponent);
    }

    public override void RemoveControlComp(MoveComponent postComponent)
    {
        m_ControlList.Remove(postComponent);
    }
}