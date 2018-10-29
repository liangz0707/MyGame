using System.Collections.Generic;
using UnityEngine;

public abstract class IMapService
{
    public abstract float GetMapHeight(Vector3 objPos);
}

public  class NullMapService: IMapService
{

    public override float GetMapHeight(Vector3 objPos)
    {
        return 0f;
    }
}

public class MapService : IMapService
{
    private Terrain m_terrain;
    public MapService()
    {
        m_terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
    }
    public MapService(Terrain t)
    {
        m_terrain = t;
    }

    public override float GetMapHeight(Vector3 objPos)
    {
        return m_terrain.SampleHeight(objPos);
    }
}