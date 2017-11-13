using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {
   
    public void Start () {
        PlayerFactory f = new PlayerFactory();
        f.CreatePlayer("Cube");

        IInputEventService m_ec = new InputEventService();
        m_ec.SetKeyMapping();
        ServiceLocator.prodive(m_ec);

        // 控制器分开比较好，根据不同类型的命令分别写
        IKeyBoardControlService m_ic = new KeyBoardControlService();
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_FORWARD, new MoveForwardCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_BACK, new MoveBackCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_LEFT, new MoveLeftCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_RIGHT, new MoveRightCommandImpl());
        m_ic.AddCommand(IInputEventService.VertualKey.MOVE_JUMP, new MoveJumpCommandImpl());
        ServiceLocator.prodive(m_ic);

        IMouseControlService m_mc = new MouseControlService();
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_RIGHTBUTTON_DOWN, new CameraTurnRightCommandImpl());
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_LEFTBUTTON_DOWN, new CameraTurnLeftCommandImpl());
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_MIDBUTTON_DOWN, new CameraZoomCommandImpl());
        ServiceLocator.prodive(m_mc);

        /*
        技能控制器也是通过命令模式，一个技能就是一个命令。
        
        1.他只要操作buff组件就可以了

        就像鼠标移动控制摄像机组件
        移动按键控制位置组件
        2.最后是点击事件，控制ui和拾取组件。
        第一第二项需要实现。
        ISkillControlService m_sc = new MouseControlService();
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_1, new SkillCommandImpl());
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_2, new SkillCommandImpl());
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_3, new SkillCommandImpl());
        ServiceLocator.prodive(m_sc);
        */
        
        ControllerCenter.Instance.AddMainPlayer(0); // 这里内部使用了服务器定位提供的服务，但是没有报错 就是应为这个机制。
        ControllerCenter.Instance.SetCameraFollow(0);
    }
	
	// Update is called once per frame
	void Update () {
        // 读取系统实际按键。并且将实际按键装换到虚拟按键。
        ServiceLocator.getEventSetvice().ResetInput();
        ServiceLocator.getEventSetvice().TranslateInput();

        // 处理每一个虚拟按键的消息
        ServiceLocator.getInputSetvice().MappingCommand();
        ServiceLocator.getMouseSetvice().MappingCommand();

        
        // 控制中心会让所有的管理器去更新管理的内容。
        ControllerCenter.Instance.Update();
    }
}
