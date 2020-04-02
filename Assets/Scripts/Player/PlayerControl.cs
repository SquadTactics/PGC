using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public List<BaseGuns> Guns;

    public int LifePlayer;
    public float SpeedMoving;
    public float RunSpeed;
    public float ForceJump;

    private float CurrentSpeedMoving;
    private bool IsLower = true;
    private bool CanRun = true;
    private Vector3 Move;
    private Animator PlayerAnimator;
    private CharacterController PController;
    private Vector3 DirectionMove;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeedMoving = SpeedMoving;

        PController = gameObject.GetComponentInChildren<CharacterController>();
        PlayerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Guns[0].Shoot();
            Debug.Log("Atirando");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Guns[0].Reload();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (IsLower)
            {
                PlayerAnimator.SetTrigger("Lower");
                IsLower = false;
                CanRun = false;
            }

            else if (!IsLower)
            {
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
        PController.SimpleMove(Move * SpeedMoving);
    }

}
