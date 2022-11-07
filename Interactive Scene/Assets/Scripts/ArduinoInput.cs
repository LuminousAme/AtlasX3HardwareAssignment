using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SerialController))]
public class ArduinoInput : MonoBehaviour
{
    SerialController controller;
    [SerializeField] float min = -1f;
    [SerializeField] float max = 1f;
    [SerializeField] float expectedMin = 0f;
    [SerializeField] float expectedMax = 1023f;
    [SerializeField] bool flipX = false;
    [SerializeField] bool flipY = false;

    float x = 0f, y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
        //read from the arduino
        string message = controller.ReadSerialMessage();

        //if there is nothing it in then discard
        if (message == null) return;

        //if it's a connection message log it
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection Established");
        //if it's a disconnect message log it 
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Disconnected");
        // process it
        if (InputSystem.instance != null) {
            string[] data = message.Split(' ');
            for(int i = 0; i < data.Length; i++)
            {
                if ((data[i][0] == 'x' || data[i][0] == 'X') && data[i].Length > 2)
                {
                    string numString = data[i].Substring(2);
                    float newX = (float)int.Parse(numString);
                    x = MathUtils.ReMap(expectedMin, expectedMax, min, max, newX);
                }
                if ((data[i][0] == 'y' || data[i][0] == 'Y') && data[i].Length > 2)
                {
                    string numString = data[i].Substring(2);
                    float newY = (float)int.Parse(numString);
                    y = MathUtils.ReMap(expectedMin, expectedMax, min, max, newY);
                }
            }

            if (flipX) x = MathUtils.ReMap(min, max, max, min, x);
            if (flipY) y = MathUtils.ReMap(min, max, max, min, y);

            InputSystem.instance.WriteStick(0, new Vector2(x, y));
        }
    }
}
