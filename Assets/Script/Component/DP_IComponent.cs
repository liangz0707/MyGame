using UnityEngine;


public interface IMoveComponent
{
    float GetGroundY(Vector3 objPos);
    Vector3 GetPosition(ref MoveData moveData);
    void Jump(ref MoveData moveData);
    void MoveBack(ref MoveData moveData);
    void MoveDown(ref MoveData moveData);
    void MoveForward(ref MoveData moveData);
    void MoveLeft(ref MoveData moveData);
    void MoveRight(ref MoveData moveData);
    void MoveUp(ref MoveData moveData);
    bool OnTheGround(ref MoveData moveData,Vector3 objPos);
    void SetCanMove(ref MoveData moveData,bool canMove);
    void SetPosition(ref MoveData moveData, Vector3 pos);
    void Update(ref MoveData moveData);
}

public interface IStateComponent 
{
    int Health { get; set; }
    int Magic { get; set; }
    float MoveSpeed { get; set; }

    void Update();
}

public interface IAttrComponent
{

}

public interface IModelComponent
{
    void Update(uint ID);
}

public interface IBuffComponent
{
    bool AddBuff(IBuffProduct buff);
    void Update();
    void UpdateState(PlayerProduct player);
}

public interface IActionCasterComponent
{
    void SetAim();
    IActionCasterComponent GetAims();
    
    Vector3 GetPosition();

    void CreateAction(ACTION_ID ActionId);
}

public interface IAnimationComponent
{

}