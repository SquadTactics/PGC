using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private List<BaseGuns> _guns;

    [SerializeField]
    private float _speedMovement;

    [SerializeField]
    private float _forceJump;

    private Camera _playerCamera;
    private PhotonView _photonView;
    private CharacterController _pController;
    private float _gravity = 9.81f;
    void Start()
    {
        _pController = gameObject.GetComponent<CharacterController>();
        _photonView = gameObject.GetComponent<PhotonView>();
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (_pController == null)
        {
            Debug.Log("Componente CharacterController faltando!");
        }

        if(_photonView == null)
        {
            Debug.Log("Sem Photon View");
        }

        if(_playerCamera == null)
        {
            Debug.Log("Player Sem Camera");
        }
        else
        {
            if (_photonView.IsMine)
            {
                _playerCamera.transform.SetParent(this.transform);
                _playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 2);
                _playerCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            Movement();
            Rotation();
            if (Input.GetButtonDown("Fire1") && _guns[0] != null)
            {
                _guns[0].Shoot();
            }

            if (Input.GetKeyDown(KeyCode.R) && _guns[0] != null)
            {
                _guns[0].Reload();
            }
        }
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move.y -= _gravity;
        move *= _speedMovement;
        move = transform.TransformDirection(move);
        _pController.Move(move * Time.deltaTime);

    }

    void Rotation()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X"), transform.localEulerAngles.z);
    }
}