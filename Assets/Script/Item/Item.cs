using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum ITEM_TYPE
{
    HANGER_ITEM,
    RECOVERY_ITEM,
    TYPE_NUM
}
// 所有物品的父类
public abstract class IItem
{
    public MoveData moveData;
    public ModelData modelData;

    public virtual void Update()
    {

    }
}
