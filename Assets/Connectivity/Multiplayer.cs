using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class multiplayer : MonoBehaviourPunCallbacks
{
    public void Enter()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene  = true;
    }

    public void JoinOrCreateRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #region PunCallbacks
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        // After connecting to master server, create the room
        JoinOrCreateRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() {MaxPlayers = 2, IsOpen = true});
    }

    public override void OnJoinedRoom()
    {
         Debug.Log("Successfully joined room: " + PhotonNetwork.CurrentRoom.Name);
        //SceneManager.LoadScene("SceneOptions");
        //proviamo a vedere se due persone vanno alla stessa scena
        PhotonNetwork.LoadLevel("Pong2P");
    }
   #endregion

}

