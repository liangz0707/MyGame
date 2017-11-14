using UnityEngine;
using UnityEditor;

public class CameraComponent : ICameraComponent
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
        if (hitted)
        {
            Vector3 v = position - hit.point;
            float distance = v.magnitude;

            if (distance <= m_distance)
            {
                m_distance = distance;
                m_position = position + distance * m_dir;
            }
            else
            {
                m_distance += m_fZoomSpeed < distance - m_distance ? m_fZoomSpeed : distance - m_distance;
                m_position = position + m_distance * m_dir;
            }
        }
        else
        {
            if (m_distance < m_curDistance)
            {
                m_distance += m_fZoomSpeed < (m_curDistance - m_distance) ? m_fZoomSpeed : m_curDistance - m_distance;
            }
            else if (m_distance > m_curDistance)
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