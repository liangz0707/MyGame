using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICameraService
{

    public abstract Ray ScreenPointToRay(Vector3 pos);
    public abstract void ZoomIn(float zoomSpeed);
    public abstract void TurnHerizental(float xOffset);

    public abstract void TurnVerticel(float yOffset);

    public abstract void GetCollider();
    public abstract void Update();
    public abstract Vector3 GetForward();
    public abstract Vector3 GetPosition();
    public abstract Vector3 GetUp();
    public abstract Vector3 GetRight();
}

public class NullCameraService : ICameraService
{

    public override Ray ScreenPointToRay(Vector3 pos)
    {
        // 
        return new Ray();
    }
    public override void ZoomIn(float zoomSpeed)
    {

    }
    public override void TurnHerizental(float xOffset)
    {

    }

    public override void TurnVerticel(float yOffset)
    {


    }

    public override Vector3 GetForward()
    {
        return Vector3.zero;
    }
    public override Vector3 GetRight()
    {
        return Vector3.zero;
    }

    public override Vector3 GetPosition()
    {

        return Vector3.zero;
    }
    public override Vector3 GetUp()
    {

        return Vector3.zero;
    }

    public override void GetCollider()
    {

    }
    public override void Update()
    {

    }
}

public class CameraService : ICameraService
{
    private Transform m_transform;
    private Vector3 m_position;
    private Vector3 m_dir; // 摄像机到角色的方向：归一化的
    private float m_distance; // 摄像机到角色的距离
    private float m_curDistance; // 摄像机到角色的距离
    private float m_fZoomSpeed;
    private const float MAX_DISTANCE = 80; // 摄像机到角色的距离
    private const float MIN_DISTANCE = 3; // 摄像机到角色的距离
    private Camera m_camera;

    public Vector3 aimPosition()
    {
        return ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.position + Vector3.up * 3.8f;
    }
    public CameraService(Camera camera)
    {
        m_camera = camera;
        m_transform = camera.transform;

        m_dir = m_transform.position - ControllerCenter.Instance.playerSystem.GetMainPlayer().moveData.position;
        m_dir.Normalize();
        m_distance = 50;
        m_curDistance = 50;
        m_fZoomSpeed = 3;
        m_position = aimPosition() + m_distance * m_dir;
    }

    public override void ZoomIn(float zoomSpeed)
    {
        m_curDistance -= zoomSpeed * 10;
        if (m_curDistance < MIN_DISTANCE) m_curDistance = MIN_DISTANCE;

        if (m_curDistance > MAX_DISTANCE) m_curDistance = MAX_DISTANCE;
    }

    public override void TurnHerizental(float xOffset)
    {

        m_dir += 0.1f * xOffset * Vector3.Cross(Vector3.up, m_dir);
        m_dir.Normalize();
    }

    public override void TurnVerticel(float yOffset)
    {
        m_dir += 0.1f * yOffset * Vector3.down;
        m_dir.Normalize();
    }
    public override void GetCollider()
    {
        Vector3 position = aimPosition();
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

    public override void Update()
    {
        GetCollider();
        m_transform.position = m_position;
        m_transform.LookAt(aimPosition());
    }

    public override Ray ScreenPointToRay(Vector3 pos)
    {
        return m_camera.ScreenPointToRay(pos);
    }

    public override Vector3 GetForward()
    {
        return m_camera.transform.forward;
    }

    public override Vector3 GetRight()
    {
        return m_camera.transform.right;
    }

    public override Vector3 GetPosition()
    {
        return m_camera.transform.position;
    }
    public override Vector3 GetUp()
    {

        return m_camera.transform.up;
    }
}