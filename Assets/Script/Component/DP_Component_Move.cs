using UnityEngine;
using UnityEditor;
using System;

// 移动组件
/* *
 *  如何处理大坡度地形。
 * */
public class MoveComponent : IMoveComponent
{

    bool isRun;

    public MoveComponent()
    {
        isRun = false;
    }

    public void MoveForward(ref MoveData moveData)
    {
        if (!moveData.movable) return;

        moveData.position += ServiceLocator.getCameraService().GetForward() * Time.deltaTime * moveData.speed;
        moveData.forward += ServiceLocator.getCameraService().GetForward();
        isRun = true;
    }

    public void MoveBack(ref MoveData moveData)
    {
        if (!moveData.movable) return;

        moveData.forward += -ServiceLocator.getCameraService().GetForward();
        moveData.position += -ServiceLocator.getCameraService().GetForward() * Time.deltaTime * moveData.speed;
        isRun = true;
    }

    public void MoveLeft(ref MoveData moveData)
    {
        if (!moveData.movable) return;

        moveData.forward += -ServiceLocator.getCameraService().GetRight();
        moveData.position += -ServiceLocator.getCameraService().GetRight() * Time.deltaTime * moveData.speed;
        isRun = true;
    }

    public void MoveRight(ref MoveData moveData)
    {
        if (!moveData.movable) return;

        moveData.forward += ServiceLocator.getCameraService().GetRight();
        moveData.position += ServiceLocator.getCameraService().GetRight()  * Time.deltaTime * moveData.speed;
        isRun = true;
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
        moveData.position = pos;
    }

    public void Jump(ref MoveData moveData)
    {
        if (!moveData.movable) return;
        if (OnTheGround(ref moveData,moveData.position))
        {
            moveData.jumpSeed = moveData.maxSpeed;
            moveData.isJumpUp = true;
            moveData.movable = false;
            moveData.jumpTime = 1.0f;
        }
    }

    public void Update(ref MoveData moveData)
    {
        if (!OnTheGround(ref moveData,moveData.position) || moveData.jumpSeed > 0)
        {
            moveData.jumpSeed -= moveData.gravity;
        }
        else
        {
            moveData.position.y = GetGroundY(moveData.position) + moveData.heightToFeet;
            moveData.jumpSeed = 0;
        }

        // 判断会不会进入地下
        if (GetGroundY(moveData.position) + moveData.heightToFeet < moveData.position.y + (Vector3.up * moveData.jumpSeed * Time.deltaTime).y)
        {
            moveData.position += Vector3.up * moveData.jumpSeed * Time.deltaTime;
        }
        else
        {
            moveData.position.y = GetGroundY(moveData.position) + moveData.heightToFeet;
        }

        moveData.jumpTime -= Time.deltaTime;
        if (moveData.jumpTime < 0f && !moveData.isAction)
        {
            moveData.movable = true;
            moveData.isJumpUp = false;
        }

        Vector3 tmp = Vector3.zero;
    
        tmp = Vector3.Cross(ServiceLocator.getCameraService().GetUp(), moveData.forward);

        moveData.forward = Vector3.Cross(tmp, Vector3.up).normalized;
        moveData.isRun = isRun;
        isRun = false;
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