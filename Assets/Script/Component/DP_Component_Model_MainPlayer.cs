using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MainPlayerModelComponent : ModelComponent
{

    public override void Update(uint ID)
    {
        PlayerProduct playerProduct;
        GameObject obj;
        bool hasPlayerData = ControllerCenter.Instance.playerSystem.Get(ID, out playerProduct);
        bool hasGameObject = ControllerCenter.Instance.gameobjectSystem.Get(ID, out obj);
        if (hasPlayerData && hasGameObject)
        {
            obj.transform.position = playerProduct.moveData.position;
            int i = obj.transform.GetInstanceID();
            obj.transform.forward = playerProduct.moveData.forward;
        }
        else
        {
            return;
        }

        MoveData moveData = playerProduct.moveData;
        bool isRun = moveData.isRun;
        bool isAction = moveData.isAction;
        
        if(isAction)
        {
            Play(obj, moveData.animationName);
            return;
        }

        if (moveData.isJumpUp)
        {
            Play(obj, "Jump");
        }
        else if(isRun)
        {
            Play(obj, "Run");
        }
        else
        {
            Play(obj, "Idle");
        }
    }

    private string cirrAnimation;
    private void Play(GameObject obj,string name)
    {
        if (cirrAnimation == name) return;
        obj.GetComponent<Animator>().CrossFade(name, 0.1f);
        cirrAnimation = name;
    }
}

