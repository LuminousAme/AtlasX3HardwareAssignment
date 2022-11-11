using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.instance != null)
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                bool state = InputSystem.instance.ReadButton(i);
                buttons[i].SetActive(state);
            }
        }
    }
}
