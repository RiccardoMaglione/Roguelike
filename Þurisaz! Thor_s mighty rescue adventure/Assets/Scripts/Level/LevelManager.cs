using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables Minimap
    public Camera Minimap;
    public Transform Player;
    Vector3 tempVec3 = new Vector3();
    #endregion

    #region Variables LoopDoor
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
    #endregion

    private void Start()
    {
        StartCoroutine(Door());
    }

    private void Update()
    {
        MinimapLock();
    }

    public void MinimapLock()
    {
        tempVec3.x = Player.position.x;
        tempVec3.y = Minimap.transform.position.y;
        tempVec3.z = Player.position.z;
        Minimap.transform.position = tempVec3;
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
                if (i >= 48)
                {
                    i = 0;
                }
            }
        }
    }












}
