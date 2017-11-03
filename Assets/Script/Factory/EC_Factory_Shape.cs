using System;
using UnityEngine;

public class ShapeFactory : IShapeFactory
{
    public override IShapeProduct CreateCube(Vector3 position)
    {
        // 初始化
        CubeProduct cube = new CubeProduct();

        // 初始化对象参数
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        String name = "CubeName";

        // 调整参数、设置组件
        gameObject.name = name;
        gameObject.AddComponent<Rigidbody>();
        gameObject.transform.position = position;

        // 装配
        cube.SetName(name);
        cube.SetGameObject(gameObject);

        ControllerCenter.Instance.AddShape(cube);

        return cube;
    }

    public override IShapeProduct CreateSphere(Vector3 position)
    {
        // 初始化
        CubeProduct sphere = new CubeProduct();

        // 初始化对象参数
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        String name = "SphereName";

        // 调整参数、设置组件
        gameObject.name = name;
        gameObject.AddComponent<Rigidbody>();
        gameObject.transform.position = position;

        // 装配
        sphere.SetName(name);
        sphere.SetGameObject(gameObject);


        ControllerCenter.Instance.AddShape(sphere);

        return sphere;
    }
}
