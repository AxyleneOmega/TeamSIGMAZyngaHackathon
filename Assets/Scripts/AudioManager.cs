using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Sources ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--- Audio Clips ---")]
    public AudioClip spaceshipEngine;
    public AudioClip swoosh;
    public AudioClip powerUp;
    public AudioClip bgm;
    public AudioClip bulletHit;
    public AudioClip highscore;
    public AudioClip destroyed;
    public AudioClip gameOver;
    public AudioClip[] breakAudios;
    public AudioClip[] bulletFiredAudios;

    public void Start()
    {
        PlayMusic(bgm, 0.2f, true);        
    }
    public void PlayMusic(AudioClip audio, float volume, bool isLooped)
    {
        musicSource.volume = volume;
        musicSource.clip = audio;
        musicSource.loop = isLooped;
        musicSource.Play(); 
    }
    public void PlaySFX(AudioClip audio, float volume)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(audio);
    }
}
