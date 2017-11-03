using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 做一些杂乱的工作，和游戏主循环。
public class MainGameLoop : MonoBehaviour {
   
    public void Start () {
        PlayerFactory f = new PlayerFactory();
        f.CreatePlayer("Cube");
        ControllerCenter.Instance.SetMainPlayer(0);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("u"))
        {
            ShapeFactory sp = new ShapeFactory();
            sp.CreateSphere(GameObject.Find("Cube").transform.position);
        }

        if (Input.GetKeyDown("c"))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Cube");
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (Input.GetKeyDown("s"))
        {
            PlayerFactory pf = new PlayerFactory();
            PlayerProduct pd = pf.CreatePlayer("Sphere");
            
            pd.GetMoveComponent().SetPosition(ControllerCenter.Instance.GetCurPlayer().GetMoveComponent().GetPosition());
        }

        if (Input.GetKeyDown("1"))
        {
            ControllerCenter.Instance.SetMainPlayer(0);
        }
        if (Input.GetKeyDown("2"))
        {
            ControllerCenter.Instance.SetMainPlayer(1);
        }
        if (Input.GetKeyDown("3"))
        {
            ControllerCenter.Instance.SetMainPlayer(2);
        }
        if (Input.GetKeyDown("4"))
        {
            ControllerCenter.Instance.SetMainPlayer(3);
        }
        if (Input.GetKeyDown("5"))
        {
            ControllerCenter.Instance.SetMainPlayer(4);
        }
        if (Input.GetKeyDown("6"))
        {
            ControllerCenter.Instance.SetMainPlayer(5);
        }
        if (Input.GetKeyDown("7"))
        {
            ControllerCenter.Instance.SetMainPlayer(6);
        }
        if (Input.GetKeyDown("8"))
        {
            ControllerCenter.Instance.SetMainPlayer(7);
        }



        ControllerCenter.Instance.Update();
    }
}
