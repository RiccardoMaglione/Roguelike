using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroLoki : MonoBehaviour
{
    public RawImage PanelLoki;
    public Texture[] Intro = new Texture[23];
    public float Cooldown = 0.1f;
    private void Start()
    {
        StartCoroutine(CicleIntro());
    }


    public IEnumerator CicleIntro()
    {
        for (int i = 0; i < 23; i++)
        {
            PanelLoki.texture = Intro[i];
            yield return new WaitForSeconds(Cooldown);
        }

    }
}
