using System;
using UnityEngine;

class Player
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

    // 下面是组件
    MoveComponent c_position;
    RenderComponent c_model;
    CameraComponent c_camera;

    // 下面是控制器
    MoveInputController c_moveInputController;
    CameraInputController c_cameraController;

    public Player(String modelName)
    {
        m_fSpeed = 12.0f;
        m_model = GameObject.Find(modelName);
        m_Transform = m_model.transform;

        // 组件
        c_position = new MoveComponent(m_Transform, m_fSpeed);
        c_model = new RenderComponent(m_model);
        c_camera = null;
    }

    public Player(String modelName, Camera camera)
    {
        m_fSpeed = 12.0f;
        m_model = GameObject.Find(modelName);
        m_Transform = m_model.transform;

        // 组件
        c_position = new MoveComponent(m_Transform, m_fSpeed);
        c_model = new RenderComponent(m_model);
        c_camera = new CameraComponent(m_Transform, camera.transform);
    }

    public void SetCameraCmp(Camera camera)
    {
        c_camera = new CameraComponent(m_Transform, camera.transform);
        if(c_position!=null) c_position.SetCamera(camera);
    }

    public void RemoveCameraCmp()
    {
        c_camera = null;
    }

    public void SetCameraController(CameraInputController cc)
    {
        c_cameraController = cc;
    }

    public void RemoveCameraController()
    {
        c_cameraController = null;
    }

    public void SetMoveInputController(MoveInputController cc)
    {
        c_moveInputController = cc;
    }

    public void RemoveMoveInputController()
    {
        c_moveInputController = null;
    }

    public void Update()
    {
        // 控制器更新
        if (c_moveInputController != null && c_position != null) c_moveInputController.MoveControl(c_position);
        if (c_cameraController != null && c_camera != null) c_cameraController.CameraControl(c_camera);

        // 组件更新
        if (c_position != null) c_position.Update();
        if(c_camera !=null) c_camera.Update();
        if(c_model != null) c_model.Update();
    }
}
