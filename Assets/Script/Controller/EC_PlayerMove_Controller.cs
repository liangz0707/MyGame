﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/*
 * 现在我丢弃了这种设计，主要是由于Unity使用完getKey之后这个消息就终止了传递，这样一次就只能控制一个组件。
 * 虽然可以把组件换成列表，但是还需要灵活的提供给别的类访问，这点 单纯的一个类太难做到了
 * 使用单例模式可以做到上一点，但是为了避免使用单例模式，我使用了服务器定位技术。不但可以灵活的切换快捷键映射，还能灵活的切换控制器。
 * 具体参考DP_InputControlService.cs类
 */

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