using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NameTransfer : MonoBehaviour
{
	//public string nameOfPlayer; //name of player
	public string saveName;
	public TMP_Text inputText;
	
	public void SetName()
	{
		PlayerPrefs.SetInt("color", 0);
		saveName = inputText.text;
		PlayerPrefs.SetString("name",saveName);
		SceneManager.LoadScene("SceneMainMenu");
	}
	
	
}
