using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StateHolder<T>
{
    private Stack<IState<T>> stateStack;

    public virtual bool EnterState(IState<T> state, bool saveBeforeState)
    {
        if(saveBeforeState)
        {
            if (stateStack.Count > 0)
            {
                IState<T> s = stateStack.Peek().HandleState(this, state);
                if (s != null)
                {
                    stateStack.Push(s);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stateStack.Push(state);
            }
        }
        else
        {
            if (stateStack.Count > 0)
            {
                IState<T> s = stateStack.Peek().HandleState(this, state);

                if (s != null)
                {
                    while (stateStack.Count > 0)
                        stateStack.Pop();
                    stateStack.Push(s);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                stateStack.Push(state);
            }
        }
        return true;
    }

    public virtual bool ExistState(IState<T> state)
    {
        if(stateStack.Count > 0 && stateStack.Peek() == state)
        {
            stateStack.Pop();
            return true;
        }
        return false;
    }
    
    public T GetState()
    {
        return stateStack.Peek().GetState();
    }
}

