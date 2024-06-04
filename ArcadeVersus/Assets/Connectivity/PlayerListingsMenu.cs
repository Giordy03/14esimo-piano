using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    private void Awake(){
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers(){
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddPlayerListing(player);
            //Debug.Log(player);
        }
    }


    public void AddPlayerListing(Player player){
        PlayerListing listing = Instantiate(_playerListing, _content);
        if (listing != null){
            listing.SetPlayerInfo(player);
            _listings.Add(listing);
            Debug.Log("Added player to listing: " + player.NickName);
        }
    }

    public void RemovePlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerListing, _content);
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){

        Debug.Log("Player entered room: " + newPlayer.NickName);
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("Player left room: " + otherPlayer.NickName);
        RemovePlayerListing(otherPlayer);
    }

}
