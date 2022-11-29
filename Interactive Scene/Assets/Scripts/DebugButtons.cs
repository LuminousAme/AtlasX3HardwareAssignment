using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(InputSystem.instance != null)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                InputSystem.instance.WriteButton(1, true);
            }
            else
            {
                InputSystem.instance.WriteButton(1, false);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                InputSystem.instance.WriteButton(0, true);
            }
            else
            {
                InputSystem.instance.WriteButton(0, false);
            }
        }
    }
}
