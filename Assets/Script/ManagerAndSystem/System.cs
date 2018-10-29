/********************************************************************
    File:           
    Description:    
    Created:        2018/10/17 14:10:19
    Author:         liangzhe    
    History:    
    Copyright (c) 2017 Perfect World, Inc. All Rights Reserved.
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class ISystem<T>
{
    protected Dictionary<uint, T> list;

    public ISystem()
    {
        list = new Dictionary<uint, T>();
    }

    public virtual void Add(uint ID,T t)
    {
        list.Add(ID,t);
    }

    public virtual void Remove(uint UID)
    {
        list.Remove(UID);
    }

    public virtual void Clear()
    {
        list.Clear();
    }

    public virtual bool Get(uint ID, out T t)
    {
        return list.TryGetValue(ID, out t);
    }

    public virtual void Update()
    {
    }

}