using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    public CreateAndJoinRooms Room2P;
   
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        { 
            Room2P.ConnectForTournament();
        }
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.AutomaticallySyncScene  = true;
    }

    public override void OnConnectedToMaster()
    {
         Room2P.JoinOrCreateRoom();
    }

   /*  public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    } */



}
