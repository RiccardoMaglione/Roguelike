using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeAudio : MonoBehaviour
{
    AudioSource source;
    public float musicVolume=1f;
    public Slider musicSlider;

    AudioSource sourceSfx;
    public float sfxVolume = 1f;
    public Slider sfxSlider;

    private void Awake()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        source = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        musicSlider.value=musicVolume;

        sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
        //sourceSfx = GameObject.FindWithTag("MusicSfx").GetComponent<AudioSource>();
        sfxSlider.value = sfxVolume;
    }

    public void ChangeVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
    public void ChangeSfx(float volumeSfx)
    {
        sfxVolume = volumeSfx;
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    void Start()
    {
        
    }

    void Update()
    {
        source.volume = musicVolume;
        sourceSfx.volume = sfxVolume;
    }
}
