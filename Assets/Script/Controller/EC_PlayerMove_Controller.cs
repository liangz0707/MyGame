using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


/* *
 * 1.控制器主要是用来控制不同单位当中的组件的，Camera和Input控制器由于需要通过按键控制，所以这里使用了命令模式来实现。
 * 2.除了这些，还需要网络控制其他玩家的位置控制器，同样是控制位置组件。
 * 3.需要按键控制之外还需要界面的按钮控制不同的对象，例如点击按钮修改角色的shader。
 * */
/*
     Normal keys: “a”, “b”, “c” …
     Number keys: “1”, “2”, “3”, …
     Arrow keys: “up”, “down”, “left”, “right”
     Keypad keys: “[1]”, “[2]”, “[3]”, “[+]”, “[equals]”
     Modifier keys: “right shift”, “left shift”, “right ctrl”, “left ctrl”, “right alt”, “left alt”, “right cmd”, “left cmd”
     Mouse Buttons: “mouse 0”, “mouse 1”, “mouse 2”, …
     Joystick Buttons (from any joystick): “joystick button 0”, “joystick button 1”, “joystick button 2”, …
     Joystick Buttons (from a specific joystick): “joystick 1 button 0”, “joystick 1 button 1”, “joystick 2 button 0”, …
     Special keys: “backspace”, “tab”, “return”, “escape”, “space”, “delete”, “enter”, “insert”, “home”, “end”, “page up”, “page down”
     Function keys: “f1”, “f2”, “f3”, …
*/


public class MoveInputController
{
    Dictionary<string, AbstractMoveCommand> m_Dictionary;

    public MoveInputController()
    {
        m_Dictionary = new Dictionary<string, AbstractMoveCommand>();
    }

    public void AddCommand(string chr, AbstractMoveCommand cmd)
    {
        m_Dictionary.Add(chr, cmd);
    }

    //Translate移动控制函数,需要判断始终的按键状态：GetKey
    public void MoveControl(MoveComponent posComponent)
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