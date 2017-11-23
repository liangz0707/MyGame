using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 享元模式的可变结构体
public struct sTrade
{

}
// 享元模式不可变结构体


// 所有物品的父类
public abstract class Item
{
    public sTrade m_sTrade;// 是否可以交易
}
