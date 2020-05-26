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
    private Animator animPlayer;

    private bool isCrouching = false;
    private bool isSprint = false;
    private float initialRotation;
    private float currentSpeedWalk;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        weaponsController = FindObjectOfType(typeof(WeaponsController)) as WeaponsController;
        animPlayer = GetComponent<Animator>();  
        playerRb = GetComponent<Rigidbody>();
        GetWeapons(weaponId);
        initialRotation = coluna.transform.rotation.x;
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
        animPlayer.SetFloat("Vertical",v);
        animPlayer.SetFloat("Horizontal",h);

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

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            isSprint = true;
            animPlayer.SetBool("Sprint", true);
        }

        else
        {
            isSprint = false;
            animPlayer.SetBool("Sprint", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isSprint)
        {
            if (!isCrouching)
            {
                animPlayer.SetBool("Crounching", true);
                isCrouching = true;
            }

            else
            {
                animPlayer.SetBool("Crounching", false);
                isCrouching = false;
            }
        }
    }
}
