using System.Collections.Generic;
using UnityEngine;
public class ItemSystem:ISystem<IItem>
{
    private IMoveComponent c_position;
    private IModelComponent c_model;
    public ItemSystem():base()
    {
        // 初始化组件
        c_model = new ModelComponent();
        c_position = new MoveComponent();
    }

    public override void Update()
    {
        foreach (uint itemID in list.Keys)
        {
            IItem item = list[itemID];
            if (c_position != null) c_position.Update(ref item.moveData);
            if (c_model != null) c_model.Update(itemID);
        }
    }
}
