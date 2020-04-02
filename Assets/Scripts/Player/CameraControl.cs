using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity;
    public GameObject TargetLook;
    public GameObject Player;

    private void Start()
    {
       
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

        //transform.LookAt(new Vector3(TargetLook.transform.position.x, transform.position.y, TargetLook.transform.position.z));
        
    }  
}
