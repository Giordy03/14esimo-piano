using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
	//[SerializeField] private AudioMixer myMixer;
	[SerializeField] private Slider volumeSlider;	



	void Start()
	{
		if (volumeSlider != null)
		{
			volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
		}
	}

	public void ChangeVolume()
	{
		AudioListener.volume = volumeSlider.value;
		Save();
	}

	private void Save()
	{
		PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
	}
}
