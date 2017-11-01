using UnityEngine;
using UnityEditor;

// 移动组件
public class PositionComponent
{
    private Transform m_Transform;
    private Vector3 m_position;
    private bool m_bInAir;
    private float m_fSpeed;
    private float m_maxSpeed;
    private float m_jumpSeed;
    private float m_gravity;

    public PositionComponent(Transform transform, float speed)
    {
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
        if (OnTheGround(m_position.y))
            m_jumpSeed = m_maxSpeed;
    }

    public Vector3 GetPosition()
    {
        return m_Transform.position;
    }

    public void Update()
    {

        if (!OnTheGround(m_position.y) || m_jumpSeed > 0)
        {
            m_jumpSeed -= m_gravity;
        }
        else
        {
            m_position.y = 0;
            m_jumpSeed = 0;
        }

        m_position += Vector3.up * m_jumpSeed * Time.deltaTime;

        m_Transform.position = m_position;
        m_Transform.up = Vector3.up;
    }

    public bool OnTheGround(float y)
    {
        RaycastHit hit;
        Ray ray = new Ray(Vector3.up * 5, Vector3.down);

        Physics.Raycast(ray, out hit, 6000);
        float hitY = hit.point.y;

        // 判断是否和地面相交
        if (hit.collider == null)
            return false;

        if (hit.collider.name == "Terrain")
            if (hitY > y)
            {
                return true;
            }
            else
            {
                return false;
            }
        else
            return false;
    }
}
