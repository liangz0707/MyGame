using UnityEngine;
using UnityEditor;

// 移动组件
/* *
 *  如何处理大坡度地形。
 * */
 public abstract class Component
{

}

public class MoveComponent: Component
{
    private Transform m_Transform;
    private Vector3 m_position;
    private float m_fSpeed;
    private float m_maxSpeed;
    private float m_jumpSeed;
    private float m_gravity;
    private Terrain m_terrain;

    public MoveComponent(Transform transform, float speed)
    {
        m_terrain = GameObject.Find("Terrain").GetComponent<Terrain>(); ;
        m_Transform = transform;
        m_fSpeed = speed;
        m_gravity = 1.8f;
        m_maxSpeed = 50;
        m_position = transform.position;
        m_jumpSeed = 0;
    }

    public void Move(Vector3 step)
    {
        m_position += step * Time.deltaTime * m_fSpeed;
    }

    public void SetPosition(Vector3 pos)
    {
        m_position = pos;
    }

    public void Jump()
    {
        if (OnTheGround(m_position))
            m_jumpSeed = m_maxSpeed;
    }

    public Vector3 GetPosition()
    {
        return m_Transform.position;
    }

    public void Update()
    {

        if (!OnTheGround(m_position) || m_jumpSeed > 0)
        {
            m_jumpSeed -= m_gravity;
        }
        else
        {
            m_position.y = GetGroundY(m_position);
            m_jumpSeed = 0;
        }

        m_position += Vector3.up * m_jumpSeed * Time.deltaTime;

        m_Transform.position = m_position;
        m_Transform.up = Vector3.up;
    }

    public bool OnTheGround(Vector3 objPos)
    {
        float y = objPos.y;
   
        float hitY = m_terrain.SampleHeight(objPos);

        if (hitY > y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetGroundY(Vector3 objPos)
    {
        float hitY = m_terrain.SampleHeight(objPos);
        return hitY;
    }
}


public class RenderComponent : Component
{
    GameObject m_model;
    public RenderComponent(GameObject model)
    {
        m_model = model;
    }

    public void Update()
    {
    }
}