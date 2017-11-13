using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {
   
    public void Start () {
        PlayerFactory f = new PlayerFactory();
        f.CreatePlayer("Cube");

        // 通过工厂创建时技能的释放过程。
        // 那技能的加载就是将技能命令提取出来。

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
        技能控制器也是通过命令模式。
        一个人使用一个技能命令。
        传入技能id，在命令模式中通过技能ID调用工厂模式创建技能，并添加到skillMan当中。
        在skillMan的update过程中，判断技能类型，控制BuffComp
        
        ISkillControlService m_sc = new MouseControlService();
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_1, 技能id);
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_2, 技能id);
        m_sc.AddCommand(IInputEventService.VertualKey.SKILL_3, 技能id);
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
