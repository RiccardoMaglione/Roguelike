using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroBattle : MonoBehaviour
{
    public RawImage Panel;
    public Texture[] Intro = new Texture[29];
    public float Cooldown = 0.1f;
    private void Start()
    {
        StartCoroutine(CicleIntro());
    }


    public IEnumerator CicleIntro()
    {
        for (int i = 0; i < 29; i++)
        {
            Panel.texture = Intro[i];
            yield return new WaitForSeconds(Cooldown);
        }

    }
}
