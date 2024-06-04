using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
	[Header ("---Audio Source---")]
	[SerializeField] AudioSource musicSource;
    	[SerializeField] AudioSource SFXSource;

	[Header ("---Audio Clip---")]
	public AudioClip background;
    	public AudioClip buttons;



	public static Audio instance;
    
    public void PlaySFX(AudioClip clip) //play a button sound
    {

    	//SFXSource.PlayOneShot(clip); 

    }
	
	private void Load()
	{
		AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
	}

private void Awake()			//avoid creating multiple AudioSource objects every time we go back to the main menu
    {

	if (instance == null)
	{
		instance = this;
		DontDestroyOnLoad(gameObject);	
	}
	else
	{
		Destroy(gameObject);
	} 

    }
	

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;			//start playing the background music
        musicSource.Play();

	
	// Store the original volume of the SFXSource
    float originalSFXVolume = SFXSource.volume;

    // Temporarily set the volume of the SFXSource to zero
    SFXSource.volume = 0f;

    // Play the button sound (which will be silent)
    PlaySFX(buttons);

    // Restore the original volume of the SFXSource
    SFXSource.volume = originalSFXVolume;
	

	if(!PlayerPrefs.HasKey("musicVolume"))		//set volume to old settings
	{
		PlayerPrefs.SetFloat("musicVolume",1);
		Load();
	}
	else
	{
		Load();
	}
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
