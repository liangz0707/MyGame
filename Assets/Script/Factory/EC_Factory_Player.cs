using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerFactory :IPlayerFactory
{
    public override PlayerProduct CreatePlayer(uint ID, uint modelID, Vector3 bornPosition)
    {
        PlayerProduct m_player;
        m_player = new PlayerProduct(ID, modelID, bornPosition);

        ControllerCenter.Instance.playerSystem.Add(ID, m_player);
        GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(PrefabMapping.Instance.PlayerModel[modelID]));
        obj.name = "MainPlayer";
        ControllerCenter.Instance.renderSystem.Add(ID, obj.GetComponent<Renderer>());
        ControllerCenter.Instance.gameobjectSystem.Add(ID, obj);

        return m_player;
    }

}