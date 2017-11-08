using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class IInputEventService
{
    public enum VertualKey
    {
        MOVE_FORWARD,
        MOVE_BACK,
        MOVE_LEFT,
        MOVE_RIGHT,
        MOVE_JUMP,
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

    public Dictionary<string, VertualKey> m_KeyMap;
    public Dictionary<string, VertualKey> m_KeyMapMove;
    public Dictionary<string, VertualKey> m_KeyMapWithCtrl;
    public Dictionary<string, VertualKey> m_KeyMapWithShift;
    public Dictionary<string, VertualKey> m_KeyMapWithAlt;

    public abstract bool IsActive(VertualKey vk);
    public abstract void SetKeyMapping();
    public abstract void TranslateInput();
    public abstract void ResetInput();
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
}

public class InputEventService: IInputEventService
{
    public InputEventService()
    {
        m_lVertualKeyState = new List<bool>();
        for (int i = 0; i < (int)VertualKey.VERTUAL_KEY_NUMBER; i++) m_lVertualKeyState.Add(false);
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
            if (Input.GetKeyDown(kvp.Key) && (Input.GetKey(KeyCode.LeftControl)|| Input.GetKey(KeyCode.RightControl)))
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapWithShift.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapWithShift)
        {
            if (Input.GetKeyDown(kvp.Key) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }

        keyCol = m_KeyMapWithAlt.Keys;
        foreach (KeyValuePair<string, VertualKey> kvp in m_KeyMapWithAlt)
        {
            if (Input.GetKeyDown(kvp.Key) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
            {
                m_lVertualKeyState[(int)kvp.Value] = true;
            }
        }
    }
}
