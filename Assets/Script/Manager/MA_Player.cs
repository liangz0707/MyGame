using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    // 需要控制当前的摄像机指向谁
    // 需要记录控制器控制的是谁
    PlayerProduct m_player;

    public PlayerManager()
    {
        m_player = null;
    }
    
    public void SetMainPlayer(PlayerProduct player)
    {
        m_player = player;
    }

    public PlayerProduct GetMainPlayer()
    {
        return m_player;
    }

    public void Update()
    {
        m_player.Update();
    }
}

