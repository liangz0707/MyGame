using UnityEngine;
using UnityEditor;
using System;

// 移动组件
/* *
 *  如何处理大坡度地形。
 * */
public class PhyicsMoveComponent : IMoveComponent
{

    public PhyicsMoveComponent()
    {
    }

    public void MoveForward(ref MoveData moveData)
    {
        if (!moveData.movable) return;


    }

    public void MoveBack(ref MoveData moveData)
    {
        if (!moveData.movable) return;

    }

    public void MoveLeft(ref MoveData moveData)
    {
        if (!moveData.movable) return;
    }

    public void MoveRight(ref MoveData moveData)
    {
        if (!moveData.movable) return;
    }

    public void MoveUp(ref MoveData moveData)
    {
        if (!moveData.movable) return;
    }

    public void MoveDown(ref MoveData moveData)
    {
        if (!moveData.movable) return;
    }

    public void SetPosition(ref MoveData moveData,Vector3 pos)
    {
        if (!moveData.movable) return;
    }

    public void Jump(ref MoveData moveData)
    {
        if (!moveData.movable) return;
    }

    public void Update(ref MoveData moveData)
    {
        moveData.position += moveData.forward * Time.deltaTime * moveData.speed;
    }

    public bool OnTheGround(ref MoveData moveData,Vector3 objPos)
    {

        float y = objPos.y;
     
        float groundY =  ServiceLocator.getMapService().GetMapHeight(objPos);

        if (groundY + moveData.heightToFeet + 0.1 >= y)  // 由于数据的精度和移动的状态  如果不加0.1 可能会造成判断错误
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetGroundY(Vector3 objPos)
    {
        float hitY = ServiceLocator.getMapService().GetMapHeight(objPos);
        return hitY;
    }

    public Vector3 GetPosition(ref MoveData moveData)
    {
        return moveData.position;
    }

    public void SetCanMove(ref MoveData moveData,bool canMove)
    {
        moveData.movable = canMove;
    }
    
}