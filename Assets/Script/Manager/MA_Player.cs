using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    // 需要控制当前的摄像机指向谁
    // 需要记录控制器控制的是谁
    List<PlayerProduct> m_players;
    Camera m_camera;
    int m_curMainPlayerIndex;

    public PlayerManager()
    {
        m_curMainPlayerIndex = -1;

        // 摄像机
        m_camera = GameObject.Find("Camera").GetComponent<Camera>();
        
        m_players = new List<PlayerProduct>();

    }

    public void RemoveMainPlayer(int i)
    {
        if (i < m_players.Count && i >= 0 && m_players[i] != null)
        {
            ServiceLocator.getInputSetvice().RemoveControlComp(m_players[i].GetMoveComponent());
            ServiceLocator.getMouseSetvice().RemoveControlComp();
        }
    }

    public void AddMainPlayer(int i)
    {
        if (i < m_players.Count && i >= 0 && m_players[i] != null)
        {
            ServiceLocator.getInputSetvice().AddControlComp(m_players[i].GetMoveComponent());
            ServiceLocator.getMouseSetvice().SetControlComp(m_players[i].GetCameraComponent());
        }
    }

    public void SetCameraFollowPlayer(int i)
    {
        if (m_curMainPlayerIndex != -1 && i < m_players.Count && i >= 0 && m_players[i] != null)
        {
            ServiceLocator.getMouseSetvice().RemoveControlComp();
            m_players[i].RemoveCameraCmp();
            m_curMainPlayerIndex = -1;
        }

        if (m_curMainPlayerIndex == -1 && i < m_players.Count && i >= 0 && m_players[i] != null)
        {
            m_players[i].SetCameraCmp(m_camera);
            ServiceLocator.getMouseSetvice().SetControlComp(m_players[i].GetCameraComponent());
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

