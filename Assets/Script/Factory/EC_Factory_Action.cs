using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ActionFactory 
{

    public  IAction CreateAction(ACTION_ID id)
    {
        IAction Action = null;
        switch (id)
        {
            case ACTION_ID.ACTION_1: Action = new Action1(); break;
            case ACTION_ID.ACTION_2: Action = new Action2(); break;
            case ACTION_ID.ACTION_3: Action = new Action3(); break;
            case ACTION_ID.ACTION_4: Action = new Action4(); break;
            case ACTION_ID.ACTION_5: Action = new Action5(); break;
            case ACTION_ID.ACTION_6: Action = new Action6(); break;
            case ACTION_ID.ACTION_DasheBackward: Action = new ActionDashBackward(); break;
            case ACTION_ID.ACTION_DasheForward: Action = new ActionDashForward(); break;
            case ACTION_ID.ACTION_Jab: Action = new ActionJab(); break;
            case ACTION_ID.ACTION_Kick: Action = new ActionKick(); break;
            case ACTION_ID.ACTION_MoveAttack1: Action = new ActionMoveAttack1(); break;
            case ACTION_ID.ACTION_MoveAttack2: Action = new ActionMoveAttack2(); break;
            case ACTION_ID.ACTION_Punch: Action = new ActionPunch(); break;
            case ACTION_ID.ACTION_RangeAttack1: Action = new ActionRangeAttack1(); break;
            case ACTION_ID.ACTION_RangeAttack2: Action = new ActionRangeAttack2(); break;
            case ACTION_ID.ACTION_SpecialAttack1: Action = new ActionSpecialAttack1(); break;
            case ACTION_ID.ACTION_SpecialAttack2: Action = new ActionSpecialAttack2(); break;
            case ACTION_ID.ACTION_Uppercut: Action = new ActionUppercut(); break;
            default: Action = new NullAction(); break;
        }
        ControllerCenter.Instance.ActionSystem.Add((uint)(Time.realtimeSinceStartup) * 100,Action);
        return Action;
    }
    
}

