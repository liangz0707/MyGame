﻿using System;
using System.Collections.Generic;
using UnityEngine;

/* *
 * 抽象工厂设计模式：
 * 在实现具体的工厂时，是每一个产品实现一个工厂，还是不同的产品共用一个工厂，需要仔细考虑。
 * 在游戏里面可能会出现很多需要生产的角色，所以一些角色需要共享工厂，然后用一些参数控制不同的状态。
 * 
 * 注意所有的工厂产生的对象 都必须加入到一个特定的管理器对象当中，否则这个对象，可能会脱离管理，始终存在。
 * */
// 生产一类产品的抽象工厂和产品
public abstract class IShapeProduct
{
    protected GameObject m_gameObj;
    protected String m_name; 
    public abstract void SetGameObject(GameObject m_gameObj);
    public abstract void SetName(String m_name);
    public abstract void Update();
}

// 角色（玩家，其他角色）工厂
public abstract class IPlayerFactory
{
    public abstract PlayerProduct CreatePlayer(uint ID, uint modelID, Vector3 bornPosition);
}

// 技能工厂
public abstract class IAction
{
    protected float time;
    protected ACTION_ID ActionID;
    public virtual bool Update()
    {
        return true;
    }
}

// Buff工厂，由于buff是附加在角色身上的，所以buff不需要加入到控制器当中，而是需要加入到角色当中，buff的处理也是在角色当中处理的。
// 所以创建buff的时候需要传入角色。
public abstract class IBuffProduct
{
    public abstract bool BeforeAttached(List<IBuffProduct> lBuffs);//buff附加之前  返回是否能附加
    public abstract bool AfterAttached(List<IBuffProduct> lBuffs);//buff附加时   
    public abstract bool Update(List<IBuffProduct> lBuffs);//buff在角色身上   返回是否需要删除
    public abstract bool Update(PlayerProduct player);//buff在角色身上   返回是否需要删除
    public abstract bool BeforeRemove(List<IBuffProduct> lBuffs);//buff在离开角色身上时  返回是否能删除
    public abstract bool AfterRemove(List<IBuffProduct> lBuffs);//buff在离开角色身上以后
}

public abstract class IBuffFactory
{
    //buff也有很多分类,其实都可以使用一种buff来定义，暂时像这样写
    public abstract IBuffProduct CreateImtHurtBuff(PlayerProduct player); // 即刻伤害buff
    public abstract IBuffProduct CreatePostiveBuff(PlayerProduct player); // 增益buff
    public abstract IBuffProduct CreateNagtiveBuff(PlayerProduct player); // 减益buff
}
