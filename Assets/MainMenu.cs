using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{      
    public void ShowKeyboardOnScreen()
    {
        TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
    } 


    //MAIN MENU
    public void Options()
    {
        SceneManager.LoadScene("SceneOptions");
    }   
    
    public void Play1P()
    {
        SceneManager.LoadScene("Scene1P");
    }
    
    public void Play2P()
    {
        SceneManager.LoadScene("ScenePvP");
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }

    //OPTIONS MENU
    public void GoToVolumeSettings()
    {
        SceneManager.LoadScene("SceneSetVolume");
    }

    public void GoToWebsite(string url)
    {
        Application.OpenURL(url);
    }

    public void Share()
    {
        SceneManager.LoadScene("SceneQRcode");
    }
    
    //PvP MENU
    public void PlayLocal()
    {
        //SceneManager.LoadScene("ScenePongPvPlocal"); //DA CAMBIAREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        SceneManager.LoadScene("Scene2PLocal");
    }

    public void PlayOnline()
    {
        SceneManager.LoadScene("Scene2POnline");
    }

    public void CreateRoom()
    {
        SceneManager.LoadScene("SceneCreateRoom");
    }

    public void JoinRoom()
    {
        SceneManager.LoadScene("SceneJoinRoom");
    }

    //IN THE ROOM
    public void PlayRoom()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }

    public void StartTetris()
    {
        SceneManager.LoadScene("Tetris");
    }

    public void StartPong1P()
    {
        SceneManager.LoadScene("Pong1P");
    }
    
    public void StartPongPvPlocal()
    {
        SceneManager.LoadScene("ScenePongPvPlocal");
    }

    public void StartPong2POnline()
    {
        SceneManager.LoadScene("Loading");
    }
}
