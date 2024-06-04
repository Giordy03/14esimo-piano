using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    private string nickName;
    // [SerializeField] private InputField roomNameInputField;
    // [SerializeField] private Button[] colorButtons;

    private void Start()
    {
        if(PlayerPrefs.HasKey("name"))
        {
            nickName = PlayerPrefs.GetString("name");
            PhotonNetwork.NickName = nickName;
        }

        Debug.Log("Nickname retrieved: " + nickName);
        PlayerPrefs.SetInt("color", 0); //maybe redundant since we are already setting the color along with the player username
    }

    /* public void SelectColor(int x)
    {
        for (int i= 0; i < colorButtons.Length; i++)
        {
            if (i == x)
            {
                colorButtons[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                colorButtons[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        PlayerPrefs.SetInt("color", x);
    } */

   /*  public void CreateRoom()
    {
        if (!string.IsNullOrEmpty(roomNameInputField.text))
            PhotonNetwork.CreateRoom(roomNameInputField.text);
    }

    public void JoinRoom()
    {
        if (!string.IsNullOrEmpty(roomNameInputField.text))
            PhotonNetwork.JoinRoom(roomNameInputField.text);
    } */


    public void JoinOrCreateRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #region PunCallbacks
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() {MaxPlayers = 2, IsOpen = true});
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = nickName;
        //PlayerPrefs.SetString("nickname", nickName);
        PhotonNetwork.LoadLevel("Game");
    }

    public void ConnectForTournament ()
    {
        PhotonNetwork.NickName = nickName;
        //PlayerPrefs.SetString("nickname", nickName);
        PhotonNetwork.LoadLevel("Game");
    }



    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Error: " + message);
    }
    #endregion
}
