﻿using UnityEngine;
public class RenderComponent 
{
    GameObject m_model;
    public RenderComponent(GameObject model)
    {
        m_model = model;
    }

    public GameObject GetModel()
    {
        return m_model;
    }
    
    public void Update()
    {
    }
}
