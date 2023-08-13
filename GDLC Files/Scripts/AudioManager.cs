using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public static AudioManager Instance;
    public AudioClip theme;
    public AudioClip damage;

    public void Awake(){
        if (Instance == null){
            Instance = this;
        }
    }


    void Start()
    {
        musicSource.clip = theme;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        sfxSource.PlayOneShot(clip);
    }


    public void ToggleMusic(){
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSfx(){
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume){
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume){
        sfxSource.volume = volume;
    }
}
