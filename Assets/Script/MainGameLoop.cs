using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    CMoveInputController ic;
    Transform t;
    PositionComponent pc;
    // Use this for initialization
    void Start () {
        t = GameObject.Find("Cube").transform;
        float s = 5.0f;
        pc = new PositionComponent(t, s);
  
        // 输入控制器，配置按键和响应
        ic = new CMoveInputController();
        ic.AddCommand("w", new MoveForwardCommandImpl(pc));
        ic.AddCommand("s", new MoveBackCommandImpl(pc));
        ic.AddCommand("a", new MoveLeftCommandImpl(pc));
        ic.AddCommand("d", new MoveRightCommandImpl(pc));
        ic.AddCommand("z", new MoveUpCommandImpl(pc));
        ic.AddCommand("x", new MoveDownCommandImpl(pc));
        ic.AddCommand("space", new MoveJumpCommandImpl(pc));
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
    }
	
	// Update is called once per frame
	void Update () {
        ic.MoveControlByTranslate();
        pc.Update();

    }
}
