using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float mvolume = musicSlider.value;
        mixer.SetFloat("Music Volume", Mathf.Log10(mvolume)*20);
        PlayerPrefs.SetFloat("musicVolume", mvolume);
    }
    public void SetSFXVolume()
    {
        float svolume = SFXSlider.value;
        mixer.SetFloat("SFX Volume", Mathf.Log10(svolume)*20);
        PlayerPrefs.SetFloat("sfxVolume", svolume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }
}
