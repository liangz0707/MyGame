using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {

    public GameObject MainPlayerPrefab;
    public Camera camera;
    public GameObject bornPoint;
    public Terrain terrain;
    public void Start () {
   
        PlayerFactory f = new PlayerFactory();
        PlayerProduct p = f.CreatePlayer(0, 0, bornPoint.transform.position);
        
        ICameraService m_cc = new CameraService(camera);
        ServiceLocator.prodive(m_cc);

        // 通过工厂创建时技能的释放过程。
        // 那技能的加载就是将技能命令提取出来。

        IInputEventService m_ec = new InputEventService();
        m_ec.SetKeyMapping();
        ServiceLocator.prodive(m_ec);

        IMapService m_mpc = new MapService(terrain);
        ServiceLocator.prodive(m_mpc);

        // 控制器分开比较好，根据不同类型的命令分别写
        IMoveControlService m_ic = new MoveControlService();
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
 
        IActionControlService m_sc = new ActionControlService();
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_1, ACTION_ID.ACTION_RangeAttack1);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_2, ACTION_ID.ACTION_RangeAttack2);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_3, ACTION_ID.ACTION_SpecialAttack1);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_4, ACTION_ID.ACTION_SpecialAttack2);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_5, ACTION_ID.ACTION_Uppercut);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_6, ACTION_ID.ACTION_DasheBackward);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_7, ACTION_ID.ACTION_DasheForward);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_8, ACTION_ID.ACTION_Kick);
        m_sc.AddCommand(IInputEventService.VertualKey.NUM_9, ACTION_ID.ACTION_MoveAttack1);

        ServiceLocator.prodive(m_sc);

    }
	
	// Update is called once per frame
	void Update () {
        // 读取系统实际按键。并且将实际按键装换到虚拟按键。
        ServiceLocator.getInputEventSetvice().ResetInput();
        ServiceLocator.getInputEventSetvice().TranslateInput();
        // 处理每一个虚拟按键的消息
        ServiceLocator.getInputSetvice().MappingCommand(ControllerCenter.Instance.playerSystem.GetMoveComponent());
        ServiceLocator.getMouseSetvice().MappingCommand();
        ServiceLocator.getActionService().MappingCommand();

        // 处理网络消息
        
        // 控制中心会让所有的管理器去更新管理的内容。
        ControllerCenter.Instance.Update();
        ServiceLocator.getCameraService().Update();
    }
}
