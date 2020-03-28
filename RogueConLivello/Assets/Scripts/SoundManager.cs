using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;
    public float DifferentAudio;

    private void Awake()
    {
        DifferentAudio = PlayerPrefs.GetFloat("MusicVolume");
        Music = FindObjectOfType<AudioSource>();
        Music.volume = DifferentAudio;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
            
    }
}
