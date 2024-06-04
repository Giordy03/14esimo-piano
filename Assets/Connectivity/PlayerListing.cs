using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;


public class PlayerListing : MonoBehaviour
{
    // [SerializeField] 
    public TextMeshProUGUI _text;
    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player){
        Player = player;
        _text.text = player.NickName;
    }

}
