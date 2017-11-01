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

    // 下面是控制器
    CMoveInputController c_moveCotroller;

    public Player(String modelName, CMoveInputController ic)
    {
        m_fSpeed = 5.0f;
        m_model = GameObject.Find(modelName);
        m_Transform = m_model.transform;

        // 组件
        c_position = new MoveComponent(m_Transform, m_fSpeed);
        c_model = new RenderComponent(m_model);

        // 控制器
        c_moveCotroller = ic;
    }

    public void Update()
    {
        // 控制器更新
        c_moveCotroller.MoveControlByTranslate(c_position);

        // 组件更新
        c_position.Update();
        c_model.Update();
    }

}
