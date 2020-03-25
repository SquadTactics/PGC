using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;

    [SerializeField]
    private int RoomSize;

    private Text textButton;

    // Start is called before the first frame update
    void Start()
    {
        this.textButton = quickStartButton.GetComponentInChildren<Text>();
        if(textButton == null)
        {
            Debug.Log("Sem Texto No Botão");
        }
    }
  
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart()
    {
        quickCancelButton.SetActive(true);
        quickStartButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Falha na conexão! Sua net é ruim.");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Criando a sala agora!");
        int randomRoomNumber = Random.Range(0, 300);
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte) RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOptions);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Falha ao criar a sala... Tente novamente!");
        CreateRoom();
    }

    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
