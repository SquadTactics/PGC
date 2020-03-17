using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public List<BaseGuns> Guns;

    public float SpeedMoving;
    public float ForceJump;

    private CharacterController PController;
    private Vector3 DirectionMove;
    // Start is called before the first frame update
    void Start()
    {
        PController = gameObject.GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if(Input.GetButtonDown("Fire1"))
        {
            Guns[0].Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Guns[0].Reload();
        }
    }

    void Moving()
    {
        DirectionMove.x = Input.GetAxis("Horizontal");
        DirectionMove.y = Input.GetAxis("Vertical");
        Vector3 Move = new Vector3(DirectionMove.x, 0, DirectionMove.y);
        PController.SimpleMove(Move * SpeedMoving);

    }
}
