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
    
    public override PlayerProduct CreatePlayer(String modeName)
    {
        PlayerProduct m_player;
        m_player = new PlayerProduct(modeName);
        ControllerCenter.Instance.AddPlayer(m_player);
        return m_player;
    }

}