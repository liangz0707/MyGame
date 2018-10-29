using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerProduct
{
    public uint UID = 0;

    // 面向数据变成，所有内容都作为一个可序列化的对象保存。
    public MoveData moveData;
    public BuffData buffData;
    public ModelData modelData;
    public ActionData ActionData;
    public AttributeData attrData;
    public StateData stateData;


    
    public PlayerProduct(uint id,uint modelId,Vector3 position)
    {
        UID = id;
        // 装配数据
        moveData = new MoveData();
        buffData = new BuffData();
        modelData = new ModelData();
        ActionData = new ActionData();
        attrData = new AttributeData();
        stateData = new StateData();

        modelData.modelId = modelId;
        moveData.speed = 13f;
        moveData.gravity = 1.8f;
        moveData.maxSpeed = 9;
        moveData.position = position;
        moveData.forward = Vector3.forward;
        moveData.jumpSeed = 0;
        moveData.heightToFeet = 0.0f;
        moveData.movable = true;
        moveData.isInAir = false;
        moveData.jumpTime = 0;
        
    }
    
}
