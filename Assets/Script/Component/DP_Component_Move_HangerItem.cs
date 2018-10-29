using UnityEngine;
using UnityEditor;
using System;

// 移动组件
/* *
 *  如何处理大坡度地形。
 * */
public class HangerItemMoveComponent : IMoveComponent
{

    public HangerItemMoveComponent()
    {
    }

    public void MoveForward(ref MoveData moveData)
    {
    }

    public void MoveBack(ref MoveData moveData)
    {

    }

    public void MoveLeft(ref MoveData moveData)
    {

    }

    public void MoveRight(ref MoveData moveData)
    {

    }

    public void MoveUp(ref MoveData moveData)
    {

    }

    public void MoveDown(ref MoveData moveData)
    {

    }

    public void SetPosition(ref MoveData moveData,Vector3 pos)
    {
        if (moveData.movable) return;
        moveData.position = pos;
    }

    public void Jump(ref MoveData moveData)
    {
    }

    public void Update(ref MoveData moveData)
    {
     
    }

    public virtual void Update(ref MoveData moveData, Vector3 followPosition)
    {
        moveData.position = followPosition;
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