using System;
using System.Collections.Generic;
using UnityEngine;

public struct MouseState
{
    public float offsetX;
    public float offsetY;
    public float zoomOffset;
    public float X;
    public float Y;
    public float terrainPos;
    public GameObject selectedItem;

    public void Set(float ox,float oy, float oz, float x,float y)
    {
        offsetX = ox;
        offsetY = oy;
        zoomOffset = oz;
        X = x;
        Y = y;
    }

    public void SetSeletedItem(GameObject m_OSelected)
    {
        selectedItem = m_OSelected;
    }
}

public abstract class IInputEventService
{
    public enum VertualKey
    {
        MOVE_FORWARD,
        MOVE_BACK,
        MOVE_LEFT,
        MOVE_RIGHT,
        MOVE_JUMP,
        MOUSE_RIGHTBUTTON_DOWN,
        MOUSE_LEFTBUTTON_DOWN,
        MOUSE_MIDBUTTON_DOWN,
        NUM_1,
        NUM_2,
        NUM_3,
        NUM_4,
        NUM_5,
        NUM_6,
        NUM_7,
        NUM_8,
        NUM_9,
        SKILL_1,
        SKILL_2,
        SKILL_3,
        SKILL_4,
        SKILL_5,
        SKILL_6,
        SKILL_7,
        SKILL_8,
        SKILL_9,

        VERTUAL_KEY_NUMBER
    }
    public List<bool> m_lVertualKeyState;
    public MouseState m_lMouseState;

    public Dictionary<string, VertualKey> m_KeyMap;
    public Dictionary<string, VertualKey> m_KeyMapMove;
    public Dictionary<string, VertualKey> m_KeyMapWithCtrl;
    public Dictionary<string, VertualKey> m_KeyMapWithShift;
    public Dictionary<string, VertualKey> m_KeyMapWithAlt;

    public abstract bool IsActive(VertualKey vk);
    public abstract void SetKeyMapping();
    public abstract void TranslateInput();
    public abstract void ResetInput();
    public abstract MouseState MousePos();
}

public class NullInputEventService: IInputEventService
{
    public NullInputEventService()
    {

    }

    public override bool IsActive(VertualKey vk)
    {
        return false;
    }

    public override void ResetInput()
    {
    }

    public override void SetKeyMapping()
    {
    }

    public override void TranslateInput()
    {
    }

    public override MouseState MousePos()
    {
        return new MouseState();
    }
}



public class InputEventService: IInputEventService
{
    GameObject m_OSelected;
    public InputEventService()
    {
        m_OSelected = null;
        m_lVertualKeyState = new List<bool>();
        for (int i = 0; i < (int)VertualKey.VERTUAL_KEY_NUMBER; i++) m_lVertualKeyState.Add(false);
        m_lMouseState = new MouseState();

        m_KeyMap = new Dictionary<string, VertualKey>();
        m_KeyMapWithCtrl = new Dictionary<string, VertualKey>();
        m_KeyMapWithShift = new Dictionary<string, VertualKey>();
        m_KeyMapWithAlt = new Dictionary<string, VertualKey>();
        m_KeyMapMove = new Dictionary<string, VertualKey>();
    }

    public override bool IsActive(VertualKey vk)
    {
        int keyIndex = (int)vk;
        if (keyIndex >= m_lVertualKeyState.Count)
            return false;
        else
            return m_lVertualKeyState[keyIndex];
    }

    public override MouseState MousePos()
    {
        return m_lMouseState;
    }


    public override void ResetInput()
    {
        for(int i = 0; i < m_lVertualKeyState.Count; i++)
        {
            m_lVertualKeyState[i] = false;
        }
    }

    public override void SetKeyMapping()
    {
        m_KeyMapMove.Add("w", VertualKey.MOVE_FORWARD);
        m_KeyMapMove.Add("s", VertualKey.MOVE_BACK);
        m_KeyMapMove.Add("a", VertualKey.MOVE_LEFT);
        m_KeyMapMove.Add("d", VertualKey.MOVE_RIGHT);
        m_KeyMapMove.Add("space", VertualKey.MOVE_JUMP);

        m_KeyMapMove.Add("mouse 0", VertualKey.MOUSE_LEFTBUTTON_DOWN);
        m_KeyMapMove.Add("mouse 1", VertualKey.MOUSE_RIGHTBUTTON_DOWN);

        m_KeyMap.Add("1", VertualKey.NUM_1);
        m_KeyMap.Add("2", VertualKey.NUM_2);
        m_KeyMap.Add("3", VertualKey.NUM_3);
        m_KeyMap.Add("4", VertualKey.NUM_4);
        m_KeyMap.Add("5", VertualKey.NUM_5);
        m_KeyMap.Add("6", VertualKey.NUM_6);
        m_KeyMap.Add("7", VertualKey.NUM_7);
        m_KeyMap.Add("8", VertualKey.NUM_8);
        m_KeyMap.Add("9", VertualKey.NUM_9);

        m_KeyMapWithAlt.Add("1", VertualKey.SKILL_1);
        m_KeyMapWithAlt.Add("2", VertualKey.SKILL_2);
        m_KeyMapWithAlt.Add("3", VertualKey.SKILL_3);
        m_KeyMapWithAlt.Add("4", VertualKey.SKILL_4);
        m_KeyMapWithAlt.Add("5", VertualKey.SKILL_5);
        m_KeyMapWithAlt.Add("6", VertualKey.SKILL_6);
        m_KeyMapWithAlt.Add("7", VertualKey.SKILL_7);
        m_KeyMapWithAlt.Add("8", VertualKey.SKILL_8);
        m_KeyMapWithAlt.Add("9", VertualKey.SKILL_9);
    }

    public override void TranslateInput()
    {
        // 记录鼠标状态
        m_lMouseState.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"), Input.mousePosition.x, Input.mousePosition.y);

        // 中键需要特殊判断
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            m_lVertualKeyState[(int)VertualKey.MOUSE_MIDBUTTON_DOWN] = true;
        }
        else
        {
            m_lVertualKeyState[(int)VertualKey.MOUSE_MIDBUTTON_DOWN] = false;
        }

        Dictionary<string, VertualKey>.KeyCollection keyCol = m_KeyMap.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMap)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapMove.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapMove)
        {
            if (Input.GetKey(kvp.Key) 
                && !(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                )
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapWithCtrl.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapWithCtrl)
        {
            if (Input.GetKeyDown(kvp.Key)
                && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                )
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapWithShift.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapWithShift)
        {
            if (Input.GetKeyDown(kvp.Key) 
                && !(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                )
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapWithAlt.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapWithAlt)
        {
            if (Input.GetKeyDown(kvp.Key)
                && !(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                &&  (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                )
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }


        if (Input.GetMouseButton(0))
        {
            Ray ray = GameObject.Find("Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);  //camare2D.ScreenPointToRay (Input.mousePosition);  
            RaycastHit hit;

            // 如果是可以拾取的物体
            if (Physics.Raycast(ray, out hit))
            {
                // 这里实现了拾取，但是和unity关系有点紧密， 这里需要在内容当中加入item的可选择组件：
                // 组件内容类型包括：NPC，物品，机关等等。
                m_OSelected = hit.collider.gameObject;
                m_lMouseState.SetSeletedItem(m_OSelected);
            }
            // 如果是地面
            else
            {
                m_OSelected = null;
            }
        }
    }
}
