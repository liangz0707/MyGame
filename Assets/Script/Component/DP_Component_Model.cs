using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ModelComponent : IModelComponent
{
    public ModelComponent()
    {
    }
    
    public virtual void Update(uint ID)
    {
        PlayerProduct playerProduct;
        GameObject obj;
        bool hasPlayerData = ControllerCenter.Instance.playerSystem.Get(ID, out playerProduct);
        bool hasGameObject = ControllerCenter.Instance.gameobjectSystem.Get(ID, out obj);
        if (hasPlayerData && hasGameObject)
        {
            obj.transform.position = playerProduct.moveData.position;
            obj.transform.forward = playerProduct.moveData.forward;
        }
    }
}

