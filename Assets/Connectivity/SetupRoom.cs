using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SetupRoom : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI output;
    public Player newPlayer;
    public PlayerListingsMenu playerListingMenu;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = PlayerPrefs.GetString("name", "Player");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        CreateRoom();
    }

    public void CreateRoom()
    {
        int roomNumb = Random.Range(10000, 100000);
        string roomName = roomNumb.ToString();
        output.text = roomName;     
        PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = 4, IsVisible = true, IsOpen = true }, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created");
        AddPlayerListing(PhotonNetwork.LocalPlayer);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined");
    }

    private void AddPlayerListing(Player player)
    {
        playerListingMenu.AddPlayerListing(player);
    }


    public void Leave()
    {
        // Debug.Log("caio");
        Debug.Log("is conncted: " + PhotonNetwork.IsConnected);
        Debug.Log("is in room: " + PhotonNetwork.InRoom);
        Debug.Log("is master client: " + PhotonNetwork.IsMasterClient);
        // if (PhotonNetwork.IsConnected & PhotonNetwork.InRoom ^ PhotonNetwork.IsMasterClient)
        // {
        // Debug.Log("funge");
        // PhotonNetwork.CurrentRoom.IsOpen = false;
        // PhotonNetwork.CurrentRoom.IsVisible = false;
        
        // List<RoomInfo> roomList;
        
        PhotonNetwork.LeaveRoom();
        // }
        // Debug.Log("NON funge");
    }


    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        
        PhotonNetwork.Disconnect();
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        SceneManager.LoadScene("SceneMainMenu");
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left: " + otherPlayer.NickName);
        if (otherPlayer.IsMasterClient)
        {
            Debug.Log("Master client left. Leaving room...");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("SceneMainMenu");
        }
    }
}
