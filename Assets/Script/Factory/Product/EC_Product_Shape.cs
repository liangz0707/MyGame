using System;
using UnityEngine;


// 生产特定类的具体BigCube工厂和产品
public class CubeProduct : IShapeProduct
{
    public override void SetGameObject(GameObject gameObj)
    {
        m_gameObj = gameObj;
    }

    public override void SetName(string name)
    {
        m_name = name;
    }

    public override void Update()
    {
    }
}

// 生产特定类的具体Shpere工厂和产品
public class ShpereProduct : IShapeProduct
{
    public override void SetGameObject(GameObject go)
    {
        m_gameObj = go;
    }

    public override void SetName(string name)
    {
        m_name = name;
    }
    public override void Update()
    {
    }
}
