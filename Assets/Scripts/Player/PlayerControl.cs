using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private List<BaseGuns> Guns;

    public int LifePlayer;
    public float SpeedMoving;
    public float RunSpeed;
    public Crosshair GunCrosshair;

    private int CurrentGun = 0;
    private float CurrentSpeedMoving;
    private float LowerMovingSpeed;
    private float VerticalMax;
    private float VerticalMin;
    private bool IsLower = true;
    private bool CanRun = true;
    private bool CanCrosshair = true;
    private Quaternion CameraRotation;
    private Camera PlayerCamera;
    private Vector3 Move;
    private Vector3 DirectionMove;
    private Animator PlayerAnimator;
    private CharacterController PController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeedMoving = SpeedMoving;
        LowerMovingSpeed = SpeedMoving / 2;

        PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        PController = gameObject.GetComponentInChildren<CharacterController>();
        PlayerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        RotationCamera();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Guns[CurrentGun].Shoot();
            Debug.Log("Atirando");
        }

        if (Input.GetKey(KeyCode.Mouse1) && CanCrosshair)
        {
            GunCrosshair.GetComponent<Crosshair>().enabled = true;
            CanCrosshair = false;
            Debug.Log("Mirando");
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GunCrosshair.GetComponent<Crosshair>().enabled = false;
            CanCrosshair = true;
            Debug.Log("Deixou de Mirar");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Guns[CurrentGun].Reload();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (IsLower)
            {
                PlayerAnimator.SetTrigger("Lower");
                GunCrosshair.GetComponent<Crosshair>().spread = 10;
                CanCrosshair = false;
                IsLower = false;
                CanRun = false; 
            }

            else if (!IsLower)
            {
                PlayerAnimator.SetTrigger("NotLower");
                GunCrosshair.GetComponent<Crosshair>().spread = 20;
                CanCrosshair = true;
                IsLower = true;
                CanRun = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (CanRun)
            { 
            PController.SimpleMove(Move * SpeedMoving * RunSpeed);
                CanCrosshair = false;
            }
        }

        else
        {
            SpeedMoving = CurrentSpeedMoving;
            CanCrosshair = true;
        }
    }

    void Moving()
    {
        DirectionMove.x = Input.GetAxis("Horizontal");
        DirectionMove.y = Input.GetAxis("Vertical");
        Move = new Vector3(DirectionMove.x, 0, DirectionMove.y);
        if (IsLower)
        {
            PController.SimpleMove(Move * SpeedMoving);
        }

        else
        {
            PController.SimpleMove(Move * LowerMovingSpeed);
        }

    }

    void RotationCamera()
    {
        CameraRotation.x = Input.GetAxis("Mouse Y");
        PlayerCamera.transform.localRotation = Quaternion.Euler(Mathf.Clamp(CameraRotation.x, VerticalMin, VerticalMax),
        CameraRotation.y, CameraRotation.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), transform.localEulerAngles.z);
    }
}