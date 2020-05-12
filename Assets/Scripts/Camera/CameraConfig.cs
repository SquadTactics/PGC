using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float turnSmooth;
    public float pivotSpeed;
    public float YRotSpeed;
    public float XRotSpeed;
    public float minAngle;
    public float maxAngle;
    public float normalZ;
    public float normalX;
    public float normalY; 
    public float aimZ;
    public float aimX;
    
}
