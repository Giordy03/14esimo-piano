using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ConnectRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomName;

    public void Enter()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = PlayerPrefs.GetString("name", "Player");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        JoinRoom();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joined");
        SceneManager.LoadScene("SceneEnteredRoom");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left: " + otherPlayer.NickName);

        Debug.Log("Master client left. Leaving room...");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("SceneMainMenu");       
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        Debug.Log("Master client left. Leaving room...");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("SceneMainMenu");
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void DisconnectUser()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }


    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        
        PhotonNetwork.Disconnect();
    }

}
