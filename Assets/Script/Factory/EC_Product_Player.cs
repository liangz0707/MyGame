using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerProduct
{    
    // 下面是组件
    private IMoveComponent c_position;
    private ICameraComponent c_camera;
    private IBuffComponent c_buff;
    private ISkillComponent c_skill;
    private IModelComponent c_model;

    // 可以用享元模式控制的内容：状态和属性
    private IAttrComponent c_attr;
    private IStateComponent c_state;

    public PlayerProduct(String modelName)
    {
        PrimitiveType code = PrimitiveType.Cube;
        if(modelName == "Cube")
        {
            code = PrimitiveType.Cube;
        }
        else if(modelName == "Sphere")
        {
            code = PrimitiveType.Sphere;
        }
        else if (modelName == "Capsule")
        {
            code = PrimitiveType.Capsule;
        }

        // 组件

        c_model = new ModelComponent(GameObject.CreatePrimitive(code));
        c_state = new StateComponent(100, 100, 12.0f);
        c_position = new MoveComponent(c_model.GetModel().transform, c_state.MoveSpeed);
        c_skill = new SkillComponent();
        c_buff = new BuffComponent();
        c_camera = null;
    }

    public PlayerProduct(String modelName, Camera camera)
    {
        PrimitiveType code = PrimitiveType.Cube;
        if (modelName == "Cube")
        {
            code = PrimitiveType.Cube;
        }
        else if (modelName == "Sphere")
        {
            code = PrimitiveType.Sphere;
        }
        else if (modelName == "Capsule")
        {
            code = PrimitiveType.Capsule;
        }

        c_model = new ModelComponent(GameObject.CreatePrimitive(code));
        c_state = new StateComponent(100, 100, 12.0f);
        c_position = new MoveComponent(c_model.GetModel().transform, c_state.MoveSpeed);
        c_buff = new BuffComponent();
        c_skill = new SkillComponent();
        c_camera = new CameraComponent(c_model.GetModel().transform, camera.transform);
    }

    public IMoveComponent GetMoveComponent()
    {
        return c_position;
    }
    
    public IBuffComponent GetBuffComponent()
    {
        return c_buff;
    }

    public ISkillComponent GetSkillComponent()
    {
        return c_skill;
    }

    public void SetCameraCmp(Camera camera)
    {
        c_camera = new CameraComponent(c_model.GetModel().transform, camera.transform);
        if(c_position!=null) c_position.SetCamera(camera);
    }

    public ICameraComponent GetCameraComponent()
    {
        return c_camera;
    }

    public void RemoveCameraCmp()
    {
        c_camera = null;
    }
    
    public void Update()
    {
        // 组件更新
        if(c_position != null) c_position.Update();
        if(c_camera !=null) c_camera.Update();
        if(c_model != null) c_model.Update();
        if (c_buff != null)
        {
            c_buff.Update();
            c_buff.UpdateState(this);
        }
    }
}
