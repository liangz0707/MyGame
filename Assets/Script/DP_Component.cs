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
        if(m_camera != null)
            m_position += Vector3.Cross(Vector3.up, -m_camera.transform.right) * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.forward * Time.deltaTime * m_fSpeed;
    }

    public void MoveBack()
    {
        if (m_camera != null)
            m_position += -Vector3.Cross(Vector3.up, -m_camera.transform.right) * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.forward * Time.deltaTime * m_fSpeed;
    }

    public void MoveLeft()
    {
        if (m_camera != null)
            m_position += -m_camera.transform.right * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.left * Time.deltaTime * m_fSpeed;
    }

    public void MoveRight()
    {
        if (m_camera != null)
            m_position += m_camera.transform.right * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.right * Time.deltaTime * m_fSpeed;
    }

    public void MoveUp()
    {
        if (m_camera != null)
            m_position += m_camera.transform.up * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.up * Time.deltaTime * m_fSpeed;
    }

    public void MoveDown()
    {
        if (m_camera != null)
            m_position += -m_camera.transform.up * Time.deltaTime * m_fSpeed;
        else
            m_position += Vector3.down * Time.deltaTime * m_fSpeed;
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
            m_position.y = GetGroundY(m_position) + m_heightToFeet;
            m_jumpSeed = 0;
        }

        // 判断会不会进入地下
        if (GetGroundY(m_position) + m_heightToFeet < m_position.y + (Vector3.up * m_jumpSeed * Time.deltaTime).y)
            m_position += Vector3.up * m_jumpSeed * Time.deltaTime;
        else
            m_position.y = GetGroundY(m_position) + m_heightToFeet;

        m_Transform.position = m_position;
        m_Transform.up = Vector3.up;

        m_Transform.forward = Vector3.Cross(m_camera.transform.right, Vector3.up);
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


public class RenderComponent 
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

public class CameraComponent
{
    private Transform m_aimTransform;
    private Transform m_transform;
    private Vector3 m_position;
    private Vector3 m_dir; // 摄像机到角色的方向：归一化的
    private float m_distance; // 摄像机到角色的距离
    private float m_curDistance; // 摄像机到角色的距离
    private float m_fZoomSpeed;
    private const float MAX_DISTANCE = 80; // 摄像机到角色的距离
    private const float MIN_DISTANCE = 10; // 摄像机到角色的距离

    public CameraComponent(Transform aimTransform, Transform cameraTransform)
    {
        m_transform = cameraTransform;
        m_aimTransform = aimTransform;

        m_dir = cameraTransform.position - aimTransform.position;
        m_dir.Normalize();
        m_distance = 50;
        m_curDistance = 50;
        m_fZoomSpeed = 3;
        m_position = m_aimTransform.position + m_distance * m_dir;
    }

    public void ZoomIn(float zoomSpeed)
    {
        m_curDistance -= zoomSpeed * 10;
        if (m_curDistance < MIN_DISTANCE) m_curDistance = MIN_DISTANCE;

        if (m_curDistance > MAX_DISTANCE) m_curDistance = MAX_DISTANCE;
    }

    public void TurnHerizental(float xOffset)
    {
       
        m_dir += 0.1f * xOffset * Vector3.Cross(Vector3.up, m_dir);
        m_dir.Normalize();
    }

    public void TurnVerticel(float yOffset)
    {
        m_dir += 0.1f * yOffset * Vector3.down;
        m_dir.Normalize();
    }
    public void GetCollider()
    {
        Vector3 position = m_aimTransform.position; 
        Ray ray = new Ray(position, m_dir);
        RaycastHit hit;
        bool hitted = Physics.Raycast(ray, out hit, m_curDistance);
        if(hitted)
        {
            Vector3 v = position - hit.point;
            float distance = v.magnitude;

            if(distance <= m_distance)
            {
                m_distance = distance;
                m_position = position + distance * m_dir;
            }
            else
            {
                m_distance += m_fZoomSpeed  < distance- m_distance ? m_fZoomSpeed: distance - m_distance;
                m_position = position + m_distance * m_dir;
            }
        }
        else
        {
            if(m_distance < m_curDistance)
            {
                m_distance += m_fZoomSpeed < (m_curDistance - m_distance) ? m_fZoomSpeed : m_curDistance - m_distance;
            }
            else if(m_distance > m_curDistance)
            {
                m_distance -= m_fZoomSpeed < m_distance - m_curDistance ? m_fZoomSpeed : m_distance - m_curDistance;
            }
            m_position = position + m_distance * m_dir;
        }
    }

    public void Update()
    {
        GetCollider();
        m_transform.position = m_position;
        m_transform.LookAt(m_aimTransform.position);
    }
}