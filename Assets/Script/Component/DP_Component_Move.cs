using UnityEngine;
using UnityEditor;

// 移动组件
/* *
 *  如何处理大坡度地形。
 * */
public class MoveComponent
{
    private Transform m_Transform;
    private Vector3 m_position;
    private float m_fSpeed;
    private float m_maxSpeed;
    private float m_jumpSeed;
    private float m_gravity;
    private Terrain m_terrain;
    private float m_heightToFeet;
    private Camera m_camera;

    public MoveComponent(Transform transform, float speed)
    {
        m_terrain = GameObject.Find("Terrain").GetComponent<Terrain>(); ;
        m_Transform = transform;
        m_fSpeed = speed;
        m_gravity = 1.8f;
        m_maxSpeed = 50;
        m_position = transform.position;
        m_jumpSeed = 0;
        m_heightToFeet = 0.5f;
        m_camera = null;
    }

    public void SetCamera(Camera camera)
    {
        m_camera = camera;
    }

    public void MoveForward()
    {
        if (m_camera != null)
            m_position += m_camera.transform.forward * Time.deltaTime * m_fSpeed;
        else
            m_position += m_Transform.forward * Time.deltaTime * m_fSpeed;
    }

    public void MoveBack()
    {
        if (m_camera != null)
            m_position += - m_camera.transform.forward * Time.deltaTime * m_fSpeed;
        else
            m_position += - m_Transform.forward * Time.deltaTime * m_fSpeed;
    }

    public void MoveLeft()
    {
        if (m_camera != null)
            m_position += - m_camera.transform.right * Time.deltaTime * m_fSpeed;
        else
            m_position += - m_Transform.right * Time.deltaTime * m_fSpeed;
    }

    public void MoveRight()
    {
        if (m_camera != null)
            m_position += m_camera.transform.right * Time.deltaTime * m_fSpeed;
        else
            m_position += m_Transform.right * Time.deltaTime * m_fSpeed;
    }

    public void MoveUp()
    {
        if (m_camera != null)
            m_position += m_camera.transform.up * Time.deltaTime * m_fSpeed;
        else
            m_position += m_Transform.up * Time.deltaTime * m_fSpeed;
    }

    public void MoveDown()
    {
        if (m_camera != null)
            m_position += - m_camera.transform.up * Time.deltaTime * m_fSpeed;
        else
            m_position += - m_Transform.up * Time.deltaTime * m_fSpeed;
    }

    public void SetPosition(Vector3 pos)
    {
        m_position = pos;
    }

    public void Jump()
    {
        if (OnTheGround(m_position))
        {
            m_jumpSeed = m_maxSpeed;
        }
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
            m_position.y = GetGroundY(m_position) + m_heightToFeet;
            m_jumpSeed = 0;
        }

        // 判断会不会进入地下
        if (GetGroundY(m_position) + m_heightToFeet < m_position.y + (Vector3.up * m_jumpSeed * Time.deltaTime).y)
        {
            m_position += Vector3.up * m_jumpSeed * Time.deltaTime;
        }
        else
        {
            m_position.y = GetGroundY(m_position) + m_heightToFeet;
        }
           
        m_Transform.position = m_position;
        m_Transform.up = Vector3.up;

        if(m_camera != null)
        {
            m_Transform.forward = Vector3.Cross(m_camera.transform.right, Vector3.up);
        }    
        else
        {
            m_Transform.forward = Vector3.Cross(m_Transform.right, Vector3.up);
        }
    }

    public bool OnTheGround(Vector3 objPos)
    {
        float y = objPos.y;

        float hitY = m_terrain.SampleHeight(objPos);

        if (hitY + m_heightToFeet + 0.1 >= y)  // 由于数据的精度和移动的状态  如果不加0.1 可能会造成判断错误
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