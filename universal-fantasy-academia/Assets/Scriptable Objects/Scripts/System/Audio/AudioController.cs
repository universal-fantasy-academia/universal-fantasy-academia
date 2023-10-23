using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	public AudioMixer mixer;
	public Slider sliderMaster;
	public Slider sliderMusic;
	public Slider sliderSFX;
	public Slider sliderVoice;

	const string VOLUME_MASTER_KEY = "VolumeMaster";
	const string VOLUME_MUSIC_KEY = "VolumeMusic";
	const string VOLUME_SFX_KEY = "VolumeSFX";
	const string VOLUME_VOICE_KEY = "VolumeVoice";

	void start()
	{
		// !!!! ATENÇÃO !!!!
		// Os sliders devem ser configurados com valores de 0.0001 a 1

		float volumeMaster = PlayerPrefs.GetFloat(VOLUME_MASTER_KEY, 1);
		sliderMaster.value = volumeMaster;

		float volumeMusic = PlayerPrefs.GetFloat(VOLUME_MUSIC_KEY, 1);
		sliderMusic.value = volumeMusic;

		float volumeSFX = PlayerPrefs.GetFloat(VOLUME_SFX_KEY, 1);
		sliderSFX.value = volumeSFX;

		float volumeVoice = PlayerPrefs.GetFloat(VOLUME_VOICE_KEY, 1);
		sliderVoice.value = volumeVoice;
	}

	public void ChangeVolumeMaster(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat(VOLUME_MASTER_KEY, volume);
		PlayerPrefs.SetFloat(VOLUME_MASTER_KEY, sliderValue);
	}

	public void ChangeVolumeMusic(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat(VOLUME_MUSIC_KEY, volume);
		PlayerPrefs.SetFloat(VOLUME_MUSIC_KEY, sliderValue);
	}

	public void SetSliderValues()
	{
		try
		{
			float volumeMaster = PlayerPrefs.GetFloat(VOLUME_MASTER_KEY, 1);
			sliderMaster.value = volumeMaster;
		}
		catch { }

		try
		{
			float volumeMusic = PlayerPrefs.GetFloat(VOLUME_MUSIC_KEY, 1);
			sliderMusic.value = volumeMusic;
		}
		catch { }

		try
		{
			float VolumeSFX = PlayerPrefs.GetFloat(VOLUME_SFX_KEY, 1);
			sliderSFX.value = VolumeSFX;
		}
		catch { }

		try
		{
			float volumeVoice = PlayerPrefs.GetFloat(VOLUME_VOICE_KEY, 1);
			sliderVoice.value = volumeVoice;
		}
		catch { }
	}

	public void ChangeVolumeSFX(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat(VOLUME_SFX_KEY, volume);
		PlayerPrefs.SetFloat(VOLUME_SFX_KEY, sliderValue);
	}

	public void ChangeVolumeVoice(float sliderValue)
	{
		float volume = Mathf.Log10(sliderValue) * 20;
		mixer.SetFloat(VOLUME_VOICE_KEY, volume);
		PlayerPrefs.SetFloat(VOLUME_VOICE_KEY, sliderValue);
	}

}
