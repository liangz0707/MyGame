/********************************************************************
    File:           
    Description:    
    Created:        2018/10/17 17:42:46
    Author:         liangzhe    
    History:    
    Copyright (c) .
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ItemFactory
{
    public static void CreateHangerItem(uint itemId, uint prefabId, Vector3 position)
    {
        HangerItem ht = new HangerItem(itemId, prefabId, position);
        GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(PrefabMapping.Instance.ItemModel[prefabId]));
        ControllerCenter.Instance.gameobjectSystem.Add(itemId,obj);
        ControllerCenter.Instance.itemSystem.Add(itemId, ht);
    }

    public static void CreateSkillItem(uint itemId, uint prefabId, Vector3 position)
    {
        SkillItem ht = new SkillItem(itemId, prefabId, position);
        GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(PrefabMapping.Instance.ItemModel[prefabId]));
        ControllerCenter.Instance.gameobjectSystem.Add(itemId, obj);
        ControllerCenter.Instance.skillitemSystem.Add(itemId, ht);
    }
}