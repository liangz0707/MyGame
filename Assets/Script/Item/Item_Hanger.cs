﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// 挂接物体
public class HangerItem : IItem
{
    uint ID;
    public HangerItem(uint itemId, uint prefabId, Vector3 position)
    {
        ID = itemId;
        moveData = new MoveData();
        moveData.position = position;
        modelData = new ModelData();
        modelData.modelId = prefabId;
    }
}