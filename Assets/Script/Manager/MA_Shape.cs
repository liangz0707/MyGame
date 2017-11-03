using System.Collections.Generic;

public class ShapeManager
{
    List<IShapeProduct> m_shapes;
    public ShapeManager()
    {
        m_shapes = new List<IShapeProduct>();
    }

    public void AddShape(IShapeProduct shape)
    {
        m_shapes.Add(shape);
    }

    public void RemoveShape(IShapeProduct shape)
    {
        m_shapes.Remove(shape);
    }

    public void ClearShapes()
    {
        m_shapes.Clear();
    }

    public void Update()
    {
        foreach (IShapeProduct shape in m_shapes)
            shape.Update();
    }
}
