using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 60f;
    public GameObject Player;

    private Vector3 Offset;

    void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
        float movementY = mouseY * sensitivity * Time.deltaTime;
        float newAngleY = transform.eulerAngles.x + mouseY;
        transform.Rotate(0f, mouseX * sensitivity * Time.deltaTime, 0f, Space.World);
        if (newAngleY <= 20 || newAngleY >= 270)
        {
            transform.Rotate(movementY, 0f, 0f);
        }
    }
}
