using System.Collections;
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
        m_ic.AddCommand("w", new MoveForwardCommandImpl());
        m_ic.AddCommand("s", new MoveBackCommandImpl());
        m_ic.AddCommand("a", new MoveLeftCommandImpl());
        m_ic.AddCommand("d", new MoveRightCommandImpl());
        m_ic.AddCommand("z", new MoveUpCommandImpl());
        m_ic.AddCommand("x", new MoveDownCommandImpl());
        m_ic.AddCommand("space", new MoveJumpCommandImpl());
        ServiceLocator.prodive(m_ic);
  
    }
	
	// Update is called once per frame
	void Update () {
        // 处理输入：每一个游戏对象（实体）的状态都保存在一个组件当中，控制器首先通过输入修改组件状态。
        ServiceLocator.getInputSetvice().TransLateInput();

        if (Input.GetKeyDown("q"))
        {
            ShapeFactory sp = new ShapeFactory();
            sp.CreateSphere(GameObject.Find("Cube").transform.position);
        }

        if (Input.GetKeyDown("e"))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Cube");
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (Input.GetKeyDown("r"))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Sphere");
            
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (Input.GetKeyDown("1"))
        {
            if(Input.GetKey("left alt"))
            {
                ControllerCenter.Instance.RemoveMainPlayer(0);
            }
            else
            {
                ControllerCenter.Instance.AddMainPlayer(0);
            }
        }
        if (Input.GetKeyDown("2"))
        {
            if (Input.GetKey("left alt"))
            {
                ControllerCenter.Instance.RemoveMainPlayer(1);
            }
            else
            {
                ControllerCenter.Instance.AddMainPlayer(1);
            }
        }
        if (Input.GetKeyDown("3"))
        {
            if (Input.GetKey("left alt"))
            {
                ControllerCenter.Instance.RemoveMainPlayer(2);
            }
            else
            {
                ControllerCenter.Instance.AddMainPlayer(2);
            }
        }
        
        // 控制中心会让所有的管理器去更新管理的内容。
        ControllerCenter.Instance.Update();
    }
}
