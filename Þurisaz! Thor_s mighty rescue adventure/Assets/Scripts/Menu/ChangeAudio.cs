using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    AudioSource musicMenu;
    public float music = 1f;
    public Slider musicSlider;
    public Text Musicperc = null;

    AudioSource sourceSfx;
    public float sfx = 1f;
    public Slider sfxSlider;
    public Text SFXperc = null;


    private void Awake()
    {
        music = PlayerPrefs.GetFloat("MusicVolume");
        musicMenu = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        //muscicMenu.volume = music;
        musicSlider.value = music;

        sfx = PlayerPrefs.GetFloat("SfxVolume");
        //sourceSfx = GameObject.FindWithTag("MusicSfx").GetComponent<AudioSource>();
        sfxSlider.value = sfx;
    }

    public void ChangeVolume()
    {
        music = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", music);
    }
    public void ChangeSfx()
    {
        sfx = sfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolume", sfx);
    }

    public void MusicText()
    {
        music = 100 * music;
        Musicperc.text = Mathf.RoundToInt(music) + "%";
    }

    public void SFXText()
    {
        sfx = 100 * sfx;
        SFXperc.text = Mathf.RoundToInt(sfx) + "%";
    }

    void Start()
    {

    }

    void Update()
    {
        ChangeVolume();
        musicMenu.volume = music;
        ChangeSfx();
        MusicText();
        SFXText();
    }
}