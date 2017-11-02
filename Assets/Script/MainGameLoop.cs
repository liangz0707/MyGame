using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO::现在做点击界面按钮 更新shader
public class MainGameLoop : MonoBehaviour {
    MoveInputController m_ic;
    CameraInputController m_icam;
    Player m_player;
    Camera m_camera;

    // Use this for initialization
    void Start () {
        m_camera = GameObject.Find("Camera").GetComponent<Camera>();
        
        m_ic = new MoveInputController();
        m_ic.AddCommand("w", new MoveForwardCommandImpl());
        m_ic.AddCommand("s", new MoveBackCommandImpl());
        m_ic.AddCommand("a", new MoveLeftCommandImpl());
        m_ic.AddCommand("d", new MoveRightCommandImpl());
        m_ic.AddCommand("z", new MoveUpCommandImpl());
        m_ic.AddCommand("x", new MoveDownCommandImpl());
        m_ic.AddCommand("space", new MoveJumpCommandImpl());

        m_icam = new CameraInputController();
        m_icam.AddCommand("mouse 0", new CameraTurnLeftCommandImpl());
        m_icam.AddCommand("mouse 1", new CameraTurnRightCommandImpl());
        m_icam.AddCommand("", new CameraZoomImpl());

        m_player = new Player("Cube");
        m_player.SetCameraCmp(m_camera);
        m_player.SetCameraController(m_icam);
        m_player.SetMoveInputController(m_ic);

    }
	
	// Update is called once per frame
	void Update () {

        m_player.Update();
    }
}
