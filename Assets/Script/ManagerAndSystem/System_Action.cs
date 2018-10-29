using System.Collections.Generic;

public class ActionSystem :ISystem<IAction>
{

    List<uint> finishedList;
    public ActionSystem(): base()
    {
        finishedList = new List<uint>();
    }
    public override void Update()
    {
        finishedList.Clear();
        foreach (uint ActionID in list.Keys)
        {
            // 根据技能类型 搜索地图，获取角色

            // 将技能存储的buff 放在角色身上。
            // 附近角色的搜索
            // 技能系统只能针对主要角色释放，所以这里的释放者就是playerMan.getMainPlayer, 只能有一个
              
            //  ** 放在角色身上这个过程就是通过工厂模式  调用需要的buff工厂并且把角色传进去
            bool finish = list[ActionID].Update();
            // 移除技能
            if (finish)
                finishedList.Add(ActionID);
        }

        foreach (uint ActionID in finishedList)
        {
            list.Remove(ActionID);
        }
        finishedList.Clear();
    }
}

