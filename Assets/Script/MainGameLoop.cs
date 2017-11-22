using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {

    public void Start () {
  
        PlayerFactory f = new PlayerFactory();
        
        PlayerProduct p = f.CreateMainPlayer("Cube");
        p.SetCameraCmp(GameObject.Find("Camera").GetComponent<Camera>());

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
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_RIGHTBUTTON_DOWN, new CameraRightCommandImpl());
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_LEFTBUTTON_DOWN, new CameraLeftCommandImpl());
        m_mc.AddCommand(IInputEventService.VertualKey.MOUSE_MIDBUTTON_DOWN, new CameraZoomCommandImpl());
        ServiceLocator.prodive(m_mc);
 
        ISkillControlService m_sc = new SkillControlService();
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_1, SKILL_ID.SKILL_1);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_2, SKILL_ID.SKILL_2);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_3, SKILL_ID.SKILL_3);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_4, SKILL_ID.SKILL_4);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_5, SKILL_ID.SKILL_5);
        ServiceLocator.prodive(m_sc);

    }
	
	// Update is called once per frame
	void Update () {
        // 读取系统实际按键。并且将实际按键装换到虚拟按键。
        ServiceLocator.getEventSetvice().ResetInput();
        ServiceLocator.getEventSetvice().TranslateInput();

        // 处理每一个虚拟按键的消息
        ServiceLocator.getInputSetvice().MappingCommand(ControllerCenter.Instance.GetMainPlayer().GetMoveComponent());
        ServiceLocator.getMouseSetvice().MappingCommand(ControllerCenter.Instance.GetMainPlayer().GetCameraComponent());
        ServiceLocator.getSkillSetvice().MappingCommand(ControllerCenter.Instance.GetMainPlayer().GetSkillCaster());

        // 处理网络消息

        // 处理状态需
        // 控制中心会让所有的管理器去更新管理的内容。
        ControllerCenter.Instance.Update();
    }
}
