using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AskUserNameOnlyTheFirstTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if(!PlayerPrefs.HasKey("name"))  //if the player does not have a name
	{		
		SceneManager.LoadScene("SceneChoosePlayerName");
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
