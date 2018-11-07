using System;
using UnityEngine;

public class EC_SceneStateController : AbstractStateController
{
    public StateHolder<PlAYER_STATE> mPlayerStateHolder;

    public EC_SceneStateController()
    {
        mPlayerStateHolder = new StateHolder<PlAYER_STATE>();
    }

}
