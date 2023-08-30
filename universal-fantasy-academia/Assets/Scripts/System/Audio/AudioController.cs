using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	public AudioMixer mixer;
	public Slider sliderMusic;
	public Slider sliderSFX;
	public Slider sliderVoice;

	void start()
	{
		// !!!! ATENÇÃO !!!!
		// Os sliders devem ser configurados com valores de 0.0001 a 1

		float volumeMusic = PlayerPrefs.GetFloat("VolumeMusic", 1);
		sliderMusic.value = volumeMusic;

		float volumeSFX = PlayerPrefs.GetFloat("VolumeSFX", 1);
		sliderSFX.value = volumeSFX;

		float volumeVoice = PlayerPrefs.GetFloat("VolumeVoice", 1);
		sliderVoice.value = volumeVoice;
	}

	public void ChangeVolumeMusic(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat("VolumeMusic", volume);
		PlayerPrefs.SetFloat("VolumeMusic", sliderValue);
	}

	public void SetSliderValues()
	{
		try
		{
			float volumeMusic = PlayerPrefs.GetFloat("VolumeMusic", 1);
			sliderMusic.value = volumeMusic;
		}
		catch { }

		try
		{
			float VolumeSFX = PlayerPrefs.GetFloat("VolumeSFX", 1);
			sliderSFX.value = VolumeSFX;
		}
		catch { }

		try
		{
			float volumeVoice = PlayerPrefs.GetFloat("VolumeVoice", 1);
			sliderVoice.value = volumeVoice;
		}
		catch { }
	}

	public void ChangeVolumeSFX(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat("VolumeSFX", volume);
		PlayerPrefs.SetFloat("VolumeSFX", sliderValue);
	}

	public void ChangeVolumeVoice(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat("VolumeVoice", volume);
		PlayerPrefs.SetFloat("VolumeVoice", sliderValue);
	}

}
