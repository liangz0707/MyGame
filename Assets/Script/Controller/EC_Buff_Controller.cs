using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 这里思考了很久，因为buff所需要的状态就在buff内部所以buff不需要在加一个组件，组件只是整合一系列内容，并保持一些状态的。
// buff不需要尾部内容，只需要角色自己的状态。
public class BuffController
{
    public BuffController()
    {

    }

    // 在加buff 之前判断是否可以加
    private void BeforeAppend()
    {
        
    }

    // 在加完buff之后的，如果是伤害直接触发
    private void AfterAppend()
    {

    }

    // 周期触发
    private void TimeTriggle()
    {

    }

    private void BeforeRemove()
    {

    }

    private void AfterRemove()
    {

    }

    public void BuffControl(BuffComponent buff)
    {

    }
}
