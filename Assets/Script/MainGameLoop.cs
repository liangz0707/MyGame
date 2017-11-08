﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {
   
    public void Start () {
        PlayerFactory f = new PlayerFactory();
        f.CreatePlayer("Cube");
        ControllerCenter.Instance.AddMainPlayer(0); // 这里内部使用了服务器定位提供的服务，但是没有报错 就是应为这个机制。
        ControllerCenter.Instance.SetCameraFollow(0); 

        IInputControlService m_ic = new InputControlService();
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_FORWARD, new MoveForwardCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_BACK, new MoveBackCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_LEFT, new MoveLeftCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_RIGHT, new MoveRightCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_JUMP, new MoveJumpCommandImpl());
        ServiceLocator.prodive(m_ic);
        
        IInputEventService m_ec = new InputEventService();
        m_ec.SetKeyMapping();
        ServiceLocator.prodive(m_ec);

    }
	
	// Update is called once per frame
	void Update () {
        // 处理输入：每一个游戏对象（实体）的状态都保存在一个组件当中，控制器首先通过输入修改组件状态。

        ServiceLocator.getEventSetvice().ResetInput();
        ServiceLocator.getEventSetvice().TranslateInput();
        ServiceLocator.getInputSetvice().TransLateInput();

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.SKILL_1))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Capsule");
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.SKILL_2))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Cube");
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.SKILL_3))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Sphere");
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_1))
            ControllerCenter.Instance.RemoveMainPlayer(0);
        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_2))
            ControllerCenter.Instance.AddMainPlayer(0);
         
        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_3))
            ControllerCenter.Instance.RemoveMainPlayer(1);

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_4))
            ControllerCenter.Instance.AddMainPlayer(1);
 

        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_5))
            ControllerCenter.Instance.RemoveMainPlayer(2);
        if (ServiceLocator.getEventSetvice().IsActive(IInputEventService.VertualKey.NUM_6))
            ControllerCenter.Instance.AddMainPlayer(2);

        
        // 控制中心会让所有的管理器去更新管理的内容。
        ControllerCenter.Instance.Update();
    }
}
