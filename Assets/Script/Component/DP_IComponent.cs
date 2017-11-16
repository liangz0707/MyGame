using UnityEngine;

public interface ICameraComponent
{
    void GetCollider();
    void TurnHerizental(float xOffset);
    void TurnVerticel(float yOffset);
    void Update();
    void ZoomIn(float zoomSpeed);
}

public interface IMoveComponent
{
    float GetGroundY(Vector3 objPos);
    Vector3 GetPosition();
    void Jump();
    void MoveBack();
    void MoveDown();
    void MoveForward();
    void MoveLeft();
    void MoveRight();
    void MoveUp();
    bool OnTheGround(Vector3 objPos);
    void SetCamera(Camera camera);
    void SetCanMove(bool canMove);
    void SetPosition(Vector3 pos);
    void Update();
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
    GameObject GetModel();
    void Update();
}

public interface IBuffComponent
{
    bool AddBuff(IBuffProduct buff);
    void Update();
    void UpdateState(PlayerProduct player);
}

public interface ISkillCasterComponent
{
    void SetAim();
    ISkillCasterComponent GetAims();
    
    Vector3 GetPosition();
}