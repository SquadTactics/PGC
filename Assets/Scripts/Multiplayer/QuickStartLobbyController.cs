using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button quickStartButton;

    [SerializeField]
    private int RoomSize;

    private Text textButton;

    // Start is called before the first frame update
    void Start()
    {
        this.textButton = quickStartButton.GetComponent<Text>();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        this.textButton.text = "Carregando!";
    }

    public void QuickStart()
    {
        this.textButton.text = "Cancelar";
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
        this.textButton.text = "Conectar";
        PhotonNetwork.LeaveRoom();
    }
}
