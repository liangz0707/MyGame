using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerProduct
{
    // 享元模式保存的恒定属性

    // 享元模式保存的非恒定属性

    // 备忘录模式的数据保存
    private Transform m_Transform;
    private GameObject m_model;
    private Vector3 m_position;
    private bool m_bInAir;
    private float m_fSpeed;
    private float m_maxSpeed;
    private List<IBuffProduct> m_buffs;

    private float m_health; //buff管理的内容
    
    // 下面是组件
    private MoveComponent c_position;
    private RenderComponent c_model;
    private CameraComponent c_camera;
    private BuffComponent c_buff;

    // 下面是控制器
    CameraInputController c_cameraController;
    BuffController c_buffController;

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

        m_fSpeed = 12.0f;
        m_model =  GameObject.CreatePrimitive(code);
        m_Transform = m_model.transform;
        m_buffs = new List<IBuffProduct>();



        // 组件
        c_position = new MoveComponent(m_Transform, m_fSpeed);
        c_model = new RenderComponent(m_model);
        c_buff = new BuffComponent(m_buffs);
        c_camera = null;
    }

    public PlayerProduct(String modelName, Camera camera)
    {
        m_fSpeed = 12.0f;
        m_model = GameObject.Find(modelName);
        m_Transform = m_model.transform;

        // 组件
        c_buff = new BuffComponent(m_buffs);
        c_position = new MoveComponent(m_Transform, m_fSpeed);
        c_model = new RenderComponent(m_model);
        c_camera = new CameraComponent(m_Transform, camera.transform);
    }

    public MoveComponent GetMoveComponent()
    {
        return c_position;
    }
    
    public BuffComponent GetBuffComponent()
    {
        return c_buff;
    }

    public void SetCameraCmp(Camera camera)
    {
        c_camera = new CameraComponent(m_Transform, camera.transform);
        if(c_position!=null) c_position.SetCamera(camera);
    }

    public CameraComponent GetCameraComponent()
    {
        return c_camera;
    }

    public void RemoveCameraCmp()
    {
        c_camera = null;
    }

    public void SetBuffController(BuffController cbuff)
    {
        c_buffController = cbuff;
    }

    public void RemoveBuffController()
    {
        c_buffController = null;
    }

    public void SetCameraController(CameraInputController cc)
    {
        c_cameraController = cc;
    }

    public void RemoveCameraController()
    {
        c_cameraController = null;
    }


    public void Update()
    {
        // 控制器更新
        if (c_cameraController != null && c_camera != null) c_cameraController.CameraControl(c_camera);
        if (c_buffController != null && c_buff != null) c_buffController.BuffControl(c_buff);

        // 组件更新
        if(c_position != null) c_position.Update();
        if(c_camera !=null) c_camera.Update();
        if(c_model != null) c_model.Update();
        if(c_buff != null) c_buff.Update();
    }
}
