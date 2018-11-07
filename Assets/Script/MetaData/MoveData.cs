/********************************************************************
    File:           
    Description:    
    Created:        2018/10/11 9:05:16
    Author:         liangzhe    
    History:    
<<<<<<< HEAD
    Copyright (c) .
=======
    Copyright (c) 2017 Perfect World, Inc. All Rights Reserved.
>>>>>>> 0e13a18dfa5fa281c2236b9df9f0e8d68c150740
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public struct MoveData
{
    public Vector3 position;
    public Vector3 forward;
    public Vector3 right;
    public float speed;
    public float maxSpeed;
    public float jumpSeed;
    public float gravity;
    public bool movable;
    public float heightToFeet;
    public float jumpTime;

    public bool isRun;
    public bool isOnRide;
    public bool isWalk;
    public bool isAttack;
    public bool isJumpUp;
    public bool isInAir;

    public bool isAction;
    public string animationName;
}