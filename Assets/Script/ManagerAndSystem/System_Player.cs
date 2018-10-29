using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem :ISystem<PlayerProduct>
{
    // 下面是组件，不保存状态，只提供操作
    private IMoveComponent c_position;
    private IBuffComponent c_buff;
    private IModelComponent c_model;
    private IAttrComponent c_attr;

    public IMoveComponent GetMoveComponent()
    {
        return c_position;
    }

    public PlayerSystem():base()
    {
        // 初始化组件
        c_model = new MainPlayerModelComponent();
        c_position = new MoveComponent();
        c_buff = new BuffComponent();
    }

    public PlayerProduct GetMainPlayer()
    {
        PlayerProduct p;
        Get(0, out p);
        return p;
    }

    public override void Update()
    {
        foreach (uint playerID in list.Keys)
        {
            PlayerProduct player = list[playerID];
            if (c_position != null) c_position.Update(ref player.moveData);
            if (c_model != null) c_model.Update(playerID);
            if (c_buff != null) c_buff.Update();
        }
    }
}


