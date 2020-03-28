using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXText : MonoBehaviour
{
    public Text mytext = null;
    public ChangeAudio sfx;
    float percentSfx;

    private void Awake()
    {
        sfx = FindObjectOfType<ChangeAudio>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        percentSfx = sfx.sfxVolume * 100;
        mytext.text = Mathf.Round(percentSfx) + " %";
    }
}
