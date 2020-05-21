using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<BaseWeapons> weapons;
    public Transform pivot;
    public Transform spawnWeapons;
    public Transform coluna;
    public Camera cameraMain;

    public float speedWalk;
    public float speedCrouching;
    public float speedSprint;
    public float lifePlayer;
    public int weaponId;

    private Rigidbody playerRb;
    private CharacterController characterController;
    private Quaternion cameraRotation;
    private WeaponsController weaponsController; 

    private bool isCrouching;
    private bool isSprint;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        weaponsController = FindObjectOfType(typeof(WeaponsController)) as WeaponsController;
        playerRb = GetComponent<Rigidbody>();
        GetWeapons(weaponId);
    }

    
    void Update()
    {
        PlayerMovement();
        PlayerInputs();
    }
    
    private void GetWeapons(int weaponId)
    {
        BaseWeapons weapon = weaponsController.GetWeapons(weaponId);
        weapon.transform.SetParent(spawnWeapons);
        weapon.gameObject.SetActive(true);
        weapon.transform.localPosition = Vector3.zero;
        weapons.Add(weapon);
    }

    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move = transform.TransformDirection(move);
        if (!isCrouching && !isSprint)
        {
            characterController.SimpleMove(move * speedWalk);
        }

        else if (isCrouching)
        {
            characterController.SimpleMove(move * speedCrouching);
        }

        else if (isSprint)
        {
            characterController.SimpleMove(move * speedSprint);
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), transform.localEulerAngles.z);
        transform.LookAt(new Vector3(pivot.position.x, transform.position.y, pivot.position.z));
    }

    void RotationBody()
    {
        float verticalMin =-35f;
        float verticalMax= 30f;
        cameraRotation.x -= Input.GetAxis("Mouse Y");
        cameraMain.transform.localRotation = Quaternion.Euler(Mathf.Clamp(cameraRotation.x, verticalMin, verticalMax),
        cameraRotation.y, cameraRotation.z);//Rotação da Camera

        coluna.transform.localRotation = Quaternion.Euler(coluna.transform.localRotation.x, Mathf.Clamp(cameraRotation.x, verticalMin, verticalMax), coluna.transform.localRotation.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), transform.localEulerAngles.z);
    }

    void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapons[0].OnShoot();
            Debug.Log("Atirando");
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            RotationBody();
            Debug.Log("Mirando");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[0].OnReload();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }

        else
        {
            isSprint = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                isCrouching = false;
                isSprint = false;
            }

            else if (!isCrouching)
            {
                isCrouching= true;
                isSprint = true;
            }
        }
    }
}
