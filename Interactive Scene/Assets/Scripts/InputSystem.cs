using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem instance;
    Vector2[] sticks = { Vector2.zero, Vector2.zero };
    bool[] buttons = { false, false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WriteStick(int index, Vector2 value)
    {
        if(index > -1 && index < sticks.Length)
        {
            sticks[index] = value;
        }
    }

    public Vector2 ReadStick(int index)
    {
        if (index > -1 && index < sticks.Length)
        {
            return sticks[index];
        }
        return Vector2.zero;
    } 
    
    public void WriteButton(int index, bool value)
    {
        if (index > -1 && index < buttons.Length)
        {
            buttons[index] = value;
        }
    }

    public bool ReadButton(int index)
    {
        if (index > -1 && index < buttons.Length)
        {
            return buttons[index];
        }
        return false;
    }
}
