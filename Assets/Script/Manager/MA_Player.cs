using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    // 需要控制当前的摄像机指向谁
    // 需要记录控制器控制的是谁
    List<PlayerProduct> m_players;
    MoveInputController m_ic;
    CameraInputController m_icam;
    BuffController m_cbuff;
    Camera m_camera;
    int m_curMainPlayerIndex;

    public PlayerManager()
    {
        m_curMainPlayerIndex = -1;
        // 角色控制
        m_ic = new MoveInputController();
        // 如果在不同的平台可能会使用不同的映射，如果使用命令模式可以非常方便的进行映射。
        m_ic.AddCommand("w", new MoveForwardCommandImpl());
        m_ic.AddCommand("s", new MoveBackCommandImpl());
        m_ic.AddCommand("a", new MoveLeftCommandImpl());
        m_ic.AddCommand("d", new MoveRightCommandImpl());
        m_ic.AddCommand("z", new MoveUpCommandImpl());
        m_ic.AddCommand("x", new MoveDownCommandImpl());
        m_ic.AddCommand("space", new MoveJumpCommandImpl());

        // 摄像机
        m_camera = GameObject.Find("Camera").GetComponent<Camera>();

        // 鼠标控制
        m_icam = new CameraInputController();
        m_icam.AddCommand("mouse 0", new CameraTurnLeftCommandImpl());
        m_icam.AddCommand("mouse 1", new CameraTurnRightCommandImpl());
        m_icam.AddCommand("", new CameraZoomImpl());

        // buff控制器
        m_cbuff = new BuffController();

        m_players = new List<PlayerProduct>();

    }

    public void SetMainPlayer(int i)
    {
        if (m_curMainPlayerIndex != -1 && i < m_players.Count && i >= 0 && m_players[i] != null)
        {
            m_players[m_curMainPlayerIndex].RemoveCameraCmp();
            m_players[m_curMainPlayerIndex].RemoveCameraController();
            m_players[m_curMainPlayerIndex].RemoveMoveInputController();
            m_players[m_curMainPlayerIndex].RemoveBuffController();
            m_curMainPlayerIndex = -1;
        }
        
        if(i < m_players.Count)
        {
            m_players[i].SetBuffController(m_cbuff);
            m_players[i].SetCameraCmp(m_camera);
            m_players[i].SetMoveInputController(m_ic);
            m_players[i].SetCameraController(m_icam);
            m_curMainPlayerIndex = i;
        }  
    }

    public void AddPlayer(PlayerProduct player)
    {
        m_players.Add(player);
    }

    public int GetPlayerNumber()
    {
        return m_players.Count;
    }

    public void RemoveShape(PlayerProduct player)
    {
        m_players.Remove(player);
    }

    public void ClearShapes()
    {
        m_players.Clear();
    }

    public PlayerProduct GetCurPlayer()
    {
        if(m_curMainPlayerIndex != -1)
        {
            return m_players[m_curMainPlayerIndex];
        }
        else
        {
            return null;
        }
    }
    public void Update()
    {
        foreach (PlayerProduct player in m_players)
            player.Update();
    }
}

