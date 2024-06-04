using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using JetBrains.Annotations;

public class TournamentSetUp : MonoBehaviourPunCallbacks
{
    public Player player1;
    public Player player2;
    
    private void Awake()
    {   //Aggiunta di ge
        PhotonNetwork.AutomaticallySyncScene = true;
        if (photonView == null)
        {
            Debug.Log("PhotonView is not attached to the GameObject qwerttrew");
        }
    // PlayerPrefs.SetInt("color", 0);
    }

    public void CreateTournament()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Is master client is true");
            PairPlayers();
        }
        else
        {
            Debug.Log("Is master client is false");
        }
    }

    private void PairPlayers()
    {
        var players = PhotonNetwork.PlayerList;
        Debug.Log(players.Length);

        // If the number of players is odd, exclude the master client
        bool isOddNumberOfPlayers = players.Length % 2 != 0;
        List<Player> playersToPair = new List<Player>(players);

        if (isOddNumberOfPlayers)
        {
            Player masterClient = PhotonNetwork.MasterClient;
            playersToPair.Remove(masterClient);
        }

        for (int i = 0; i < playersToPair.Count; i += 2)
        {
            if (i + 1 < playersToPair.Count)
            {
                player1 = playersToPair[i];
                player2 = playersToPair[i + 1];
                Debug.Log("player 1 = " + playersToPair[i] + " player 2 = " + playersToPair[i + 1]);
                //AssignMatch(playersToPair[i], playersToPair[i + 1]);
                StartMatch(playersToPair[i], playersToPair[i + 1]);

            }
        }

        if (isOddNumberOfPlayers)
        {
            Debug.Log("The master client will skip the first round.");
        }
    }


    private void StartMatch(Player player1, Player player2)
    {
        Debug.Log("Starting match between " + player1.NickName + " and " + player2.NickName);
        
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Game");  // Ensure this scene name matches the actual scene you want to load
        }
    }
/* 
    private void AssignMatch(Player player1, Player player2)
    {
        if (player1 == null)
        {
            Debug.LogError("Player1 is null");
        }
        if (player2 == null)
        {
            Debug.LogError("Player2 is null");
        }

        
        photonView.RPC("LoadPongScene", player1, player2.NickName);
        photonView.RPC("LoadPongScene", player2, player1.NickName);
    } */

    [PunRPC]
    void LoadPongScene(string opponentName)
    {
        // Logic to start the match against the opponent
        Debug.Log("Your opponent is: " + opponentName);
        
        // Load the Pong2P scene
        // SceneManager.LoadScene("Loading");
        if (PhotonNetwork.IsMasterClient)
        {
            //commentato da ge
            //PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel("Game");
        }
        // Store opponent name to use in the game scene
        PlayerPrefs.SetString("OpponentName", opponentName);
    }

    // Called when the match ends
    public void OnMatchEnd()
    {
        photonView.RPC("RequestScores", RpcTarget.All);
    }

    [PunRPC]
    void RequestScores()
    {
        // Assuming GameManagerPong2P is the script managing the Pong game
        GameManager2P gameManager = FindObjectOfType<GameManager2P>();
        if (gameManager != null)
        {
            int player1Score = gameManager.player1Score;
            int player2Score = gameManager.player2Score;
            
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
            {
                // Local player is player 1
                photonView.RPC("SubmitScores", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, player1Score, player2Score);
            }
            else
            {
                // Local player is player 2
                photonView.RPC("SubmitScores", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, player2Score, player1Score);
            }
        }
    }
    [PunRPC]
    void SubmitScores(Player player, int playerScore, int opponentScore)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (playerScore < opponentScore)
            {
                photonView.RPC("EliminatePlayer", RpcTarget.All, player);
            }

            CheckForWinner();
        }
    }

    [PunRPC]
    void EliminatePlayer(Player player)
    {
        if (player != null)
        {
            if (player.IsMasterClient)
            {
                Debug.Log("MasterClient is being eliminated, reassigning...");
                PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerListOthers[0]);
            }
            PhotonNetwork.CloseConnection(player);
        }
    }

    void CheckForWinner()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Player winner = PhotonNetwork.PlayerList[0];
            Debug.Log("The winner is: " + winner.NickName);
            // Handle winner declaration
        }
        else
        {
            // Proceed to the next round
            PairPlayers();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        CheckForWinner();
    }

}
