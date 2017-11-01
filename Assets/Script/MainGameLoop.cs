using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    CMoveInputController ic;
    Player player1, player2;
    // Use this for initialization
    void Start () {

        ic = new CMoveInputController();
        ic.AddCommand("w", new MoveForwardCommandImpl());
        ic.AddCommand("s", new MoveBackCommandImpl());
        ic.AddCommand("a", new MoveLeftCommandImpl());
        ic.AddCommand("d", new MoveRightCommandImpl());
        ic.AddCommand("z", new MoveUpCommandImpl());
        ic.AddCommand("x", new MoveDownCommandImpl());
        ic.AddCommand("space", new MoveJumpCommandImpl());

        player1 = new Player("Cube", ic);
        player2 = new Player("Sphere", ic);
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

        player1.Update();
        player2.Update();
    }
}
