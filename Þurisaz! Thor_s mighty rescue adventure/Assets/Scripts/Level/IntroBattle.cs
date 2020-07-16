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
            if (i == 22)                                //Frame numero 23
            {
                Panel.texture = Intro[i];
                yield return new WaitForSeconds(1);
            }
            else if(i == 28)                            //Frame numero 29
            {
                Panel.texture = Intro[i];
                yield return new WaitForSeconds(1.30f);
            }
            else
            {
                Panel.texture = Intro[i];
                yield return new WaitForSeconds(Cooldown);
            }
        }
    }
}