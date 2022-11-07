using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] float scale;
    // Update is called once per frame
    void Update()
    {
        if(InputSystem.instance != null)
        {
            Vector2 input = InputSystem.instance.ReadStick(0);
            input *= 0.5f * scale;
            transform.position = new Vector3(input.x, input.y, -1f);
        }
    }
}
