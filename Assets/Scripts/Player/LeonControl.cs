using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeonControl : MonoBehaviour
{
    [SerializeField]
    private List<BaseGuns> Guns;

    public int LifePlayer;
    public float SpeedMoving;
    public float RunSpeed;
    public float VerticalMax;
    public float VerticalMin;
    public GameObject Coluna;

    private int CurrentGun = 0;
    private float CurrentSpeedMoving;
    private float LowerMovingSpeed;
    private bool IsLower = true;
    private bool CanRun = true;
    private Camera PlayerCamera;
    private Quaternion CameraRotation;
    private Vector3 Move;
    private Vector3 DirectionMove;
    private Animator PlayerAnimator;
    private CharacterController PController;


    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeedMoving = SpeedMoving;
        LowerMovingSpeed = SpeedMoving / 2;

        PController = gameObject.GetComponentInChildren<CharacterController>();
        PlayerAnimator = gameObject.GetComponent<Animator>();
        PlayerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        PlayerCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
        CameraRotation = PlayerCamera.transform.localRotation;
        Cursor.visible = false; //Deixar Mouse Invisivel
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();
        Rotation();

        if (Input.GetKeyDown(KeyCode.R))
        {
            Guns[CurrentGun].Reload();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (IsLower)
            {
                Guns[CurrentGun].TamMira(10f);//Spread apenas visual, Falta implementar nas balas
                PlayerAnimator.SetTrigger("Lower");
                IsLower = false;
                CanRun = false;
            }

            else if (!IsLower)
            {
                Guns[CurrentGun].TamMira(20f);//Spread apenas visual, Falta implementar nas balas
                PlayerAnimator.SetTrigger("NotLower");
                IsLower = true;
                CanRun = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (CanRun)
            {
                PController.SimpleMove(Move * SpeedMoving * RunSpeed);
            }
        }

        else
        {
            SpeedMoving = CurrentSpeedMoving;
        }
    }

    void Moving()
    {
        DirectionMove.x = Input.GetAxis("Horizontal");
        DirectionMove.y = Input.GetAxis("Vertical");
        Move = new Vector3(DirectionMove.x, 0, DirectionMove.y);
        Move = transform.TransformDirection(Move);//Ajusta Movimentação do personagem ao Rotacionar camera
        if (IsLower)
        {
            PController.SimpleMove(Move * SpeedMoving);
        }

        else
        {
            PController.SimpleMove(Move * LowerMovingSpeed);
        }

    }
    void Rotation()
    {
        CameraRotation.x -= Input.GetAxis("Mouse Y");
        PlayerCamera.transform.localRotation = Quaternion.Euler(Mathf.Clamp(CameraRotation.x, VerticalMin, VerticalMax),
           CameraRotation.y, CameraRotation.z);//Rotação da Camera
        Coluna.transform.localRotation = Quaternion.Euler(Coluna.transform.localRotation.x,Mathf.Clamp(CameraRotation.x, VerticalMin, VerticalMax), Coluna.transform.localRotation.z);//Rotação da Coluna
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), transform.localEulerAngles.z);
        
    }
    void Shooting()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Guns[CurrentGun].DrawnSight();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Guns[CurrentGun].Shoot();
                Debug.Log("Atirando");
            }
            Debug.Log("Mirando");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Guns[CurrentGun].EraseSight();
        }
    }
}
