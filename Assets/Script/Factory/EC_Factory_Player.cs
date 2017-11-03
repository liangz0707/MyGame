using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerFactory :IPlayerFactory
{
    public override PlayerProduct CreateElsePlayer()
    {
        return new PlayerProduct("Shpere");
    }

    public override PlayerProduct CreatePlayer(MoveInputController m_ic, CameraInputController m_icam, Camera m_camera)
    {
        PlayerProduct m_player;

        m_player = new PlayerProduct("Cube");
        m_player.SetCameraCmp(m_camera);
        m_player.SetCameraController(m_icam);
        m_player.SetMoveInputController(m_ic);

        ControllerCenter.Instance.AddPlayer(m_player);
        return m_player;
    }

    public override PlayerProduct CreatePlayer(String modeName)
    {
        PlayerProduct m_player;
        m_player = new PlayerProduct(modeName);
        ControllerCenter.Instance.AddPlayer(m_player);
        return m_player;
    }

    public override PlayerProduct CreatePlayer(MoveInputController m_ic, CameraInputController m_icam, Camera m_camera, BuffController m_cbuff)
    {
        PlayerProduct m_player;

        m_player = new PlayerProduct("Cube");
        m_player.SetCameraCmp(m_camera);
        m_player.SetCameraController(m_icam);
        m_player.SetMoveInputController(m_ic);
        m_player.SetBuffController(m_cbuff);

        ControllerCenter.Instance.AddPlayer(m_player);
        return m_player;
    }
}