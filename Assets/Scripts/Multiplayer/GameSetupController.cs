using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    private void CreatePlayer()
    {
        Debug.Log("Criando Jogador");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"), Vector3.zero, Quaternion.identity);
    }
}
