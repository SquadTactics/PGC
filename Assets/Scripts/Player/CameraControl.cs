using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity;
    public float sensitivityY;
    public Transform Target;
 
    private Vector3 offset;
    private float MinimunY = -30f;
    private float MaximumY = 30f;
    private float RotationY;
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");
        RotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        RotationY = Mathf.Clamp(RotationY, MinimunY, MaximumY);
        transform.localEulerAngles = new Vector3(-RotationY, transform.localEulerAngles.y, 0);
        transform.Rotate(0f, mouseX * sensitivity * Time.deltaTime, 0f, Space.World);
        
    }
}
