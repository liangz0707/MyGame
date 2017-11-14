using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ModelComponent : IModelComponent
{
    GameObject m_model;
    public ModelComponent(GameObject obj)
    {
        m_model = obj;
    }

    public GameObject GetModel()
    {
        return m_model;
    }

    public void Update()
    {
        
    }
}

