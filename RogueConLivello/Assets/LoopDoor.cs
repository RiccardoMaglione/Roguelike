using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDoor : MonoBehaviour
{
    public Renderer GraphicsDoor1;
    public Renderer GraphicsDoor2;
    public Renderer GraphicsDoor3;
    public Renderer GraphicsDoor4;
    public Renderer GraphicsDoor5;
    public Renderer GraphicsDoor6;
    public Renderer GraphicsDoor7;
    public Renderer GraphicsDoor8;
    public Renderer GraphicsDoor9;
    public Material[] MaterialChange = new Material[48];
    int i = 0;

    private void Start()
    {
        StartCoroutine(Door());
    }

    IEnumerator Door()
    {
        while (true)
        {
            for (int i = 0; i < 48; i++)
            {
                yield return new WaitForSeconds((float)0.1);
                GraphicsDoor1.material = MaterialChange[i];
                GraphicsDoor2.material = MaterialChange[i];
                GraphicsDoor3.material = MaterialChange[i];
                GraphicsDoor4.material = MaterialChange[i];
                GraphicsDoor5.material = MaterialChange[i];
                GraphicsDoor6.material = MaterialChange[i];
                GraphicsDoor7.material = MaterialChange[i];
                GraphicsDoor8.material = MaterialChange[i];
                GraphicsDoor9.material = MaterialChange[i];
                if (i>=48)
                {
                    i = 0;
                }
            }
        }
    }
}
