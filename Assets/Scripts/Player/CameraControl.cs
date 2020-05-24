using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float distance;
    public float yHigh;
    public float sensibility;
    public float minY;
    public float maxY;

    private float x =0;
    private float y = 0;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            x += Input.GetAxis("Mouse X") * sensibility * 0.02f;
            y -= Input.GetAxis("Mouse Y") * sensibility * 0.02f;
            y = Mathf.Clamp(y, maxY, minY);

            Quaternion rotationObject = Quaternion.Euler(y, x, 0);
            Vector3 positionObject = rotationObject * new Vector3(0, yHigh, 0 - distance) + target.position;

            transform.rotation = rotationObject;
            transform.position = positionObject;
        }
    }
}
