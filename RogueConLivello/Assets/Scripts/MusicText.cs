using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicText : MonoBehaviour
{
    public Text mytext = null;
    public ChangeAudio music;
    float percentMusic;

    private void Awake()
    {
        music = FindObjectOfType<ChangeAudio>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percentMusic = music.musicVolume * 100;     
        mytext.text =Mathf.Round(percentMusic)+ " %";
        

    }
}
