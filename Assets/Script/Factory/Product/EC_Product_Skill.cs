using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

public enum ACTION_ID
{
    ACTION_NULL,
    ACTION_1,
    ACTION_2,
    ACTION_3,
    ACTION_4,
    ACTION_5,
    ACTION_6,
    ACTION_Uppercut,
    ACTION_Punch,
    ACTION_Jab,
    ACTION_Kick,
    ACTION_SpecialAttack1,
    ACTION_SpecialAttack2,
    ACTION_MoveAttack1,
    ACTION_MoveAttack2,
    ACTION_RangeAttack1,
    ACTION_RangeAttack2,
    ACTION_DasheForward,
    ACTION_DasheBackward,
    ACTION_NUM,
}

public class NullAction : IAction
{
    public NullAction()
    {
        ActionID = ACTION_ID.ACTION_NULL;
    }
}

public class Action1 : IAction
{
    public Action1()
    {
        ActionID = ACTION_ID.ACTION_1;
    }
}

public class Action2 : IAction
{
    public Action2()
    {
        ActionID = ACTION_ID.ACTION_2;
    }
}

public class Action3 : IAction
{
    public Action3()
    {
        ActionID = ACTION_ID.ACTION_3;
    }

}

public class Action4 : IAction
{
    public Action4()
    {
        ActionID = ACTION_ID.ACTION_4;
    }

}

public class Action5 : IAction
{
    public Action5()
    {
        ActionID = ACTION_ID.ACTION_5;
    }

}

public class Action6 : IAction
{
    public Action6()
    {
        ActionID = ACTION_ID.ACTION_6;
    }
}

public class ActionDashBackward : IAction
{


    public ActionDashBackward()
    {
        ActionID = ACTION_ID.ACTION_DasheBackward;

        MoveData moveData = ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData;
        if (moveData.isAction) return;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 0.3f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "DashBackward";

        ItemFactory.CreateSkillItem(4, 0, moveData.position);
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.position += -ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.forward.normalized * 15f * Time.deltaTime;
        return false;
    }
}
public class ActionDashForward : IAction
{

    public ActionDashForward()
    {
        ActionID = ACTION_ID.ACTION_DasheForward;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
       
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 0.3f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "DashForward";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }

        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.position += ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.forward.normalized * 15f * Time.deltaTime;
        return false;
    }
}
public class ActionMoveAttack1 : IAction
{

    public ActionMoveAttack1()
    {
        ActionID = ACTION_ID.ACTION_MoveAttack1;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "MoveAttack1";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}
public class ActionMoveAttack2 : IAction
{
    public ActionMoveAttack2()
    {
        ActionID = ACTION_ID.ACTION_MoveAttack2;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "MoveAttack2";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}
public class ActionSpecialAttack1 : IAction
{
    public ActionSpecialAttack1()
    {
        ActionID = ACTION_ID.ACTION_SpecialAttack1;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;

        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "SpecialAttack1";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}
public class ActionSpecialAttack2 : IAction
{

    public ActionSpecialAttack2()
    {
        ActionID = ACTION_ID.ACTION_SpecialAttack2;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;

        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "SpecialAttack2";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}
public class ActionRangeAttack1 : IAction
{


    public ActionRangeAttack1()
    {
        ActionID = ACTION_ID.ACTION_RangeAttack1;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        time = 1f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "RangeAttack1";
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.jumpSeed = 3;
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.position += ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.forward.normalized * 5f * Time.deltaTime;
        

        return false;
    }
}

public class ActionRangeAttack2 : IAction
{

    public ActionRangeAttack2()
    {
        ActionID = ACTION_ID.ACTION_RangeAttack2;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;

        time = 1f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "RangeAttack2";
    }

    public override bool Update()
    {

        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}

public class ActionUppercut : IAction
{
    public ActionUppercut()
    {
        ActionID = ACTION_ID.ACTION_Uppercut;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;

        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "Uppercut";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}

public class ActionPunch : IAction
{

    public ActionPunch()
    {
        ActionID = ACTION_ID.ACTION_Punch;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "Punch";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}

public class ActionJab : IAction
{
   
    public ActionJab()
    {
        ActionID = ACTION_ID.ACTION_Jab;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "Jab";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}

public class ActionKick : IAction
{

    public ActionKick()
    {
        ActionID = ACTION_ID.ACTION_Kick;
        if (ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction) return;
        
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = true;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = false;
        time = 1.0f;
        ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "Kick";
    }

    public override bool Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.isAction = false;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.movable = true;
            ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.animationName = "";
            return true;
        }
        return false;
    }
}