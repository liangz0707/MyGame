using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class IPlayerStateHolder
{
    protected IPlayerState s_state;
    public virtual void SetState(IPlayerState state)
    {
        if (s_state != null)
        {
            if (!s_state.Stop()) // 表示是否成功停止。
            {
                return;
            }
        }
        state.SetHolder(this);
        state.Begin();
        s_state = state;
    }

    public void StateUpdate()
    {
        s_state.Update();
    }
}

public  class PlayerStateHolder :IPlayerStateHolder
{

}
