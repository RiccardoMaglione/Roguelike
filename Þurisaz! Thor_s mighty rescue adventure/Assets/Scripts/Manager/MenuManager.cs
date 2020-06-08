using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region Follow Image
    public GameObject WoW;
    public Button[] ButtonMenu = new Button[5];
    public void FollowPlay()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x - 20, ButtonMenu[0].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowPlayEsc()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x + 20, ButtonMenu[0].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowMonsterpedia()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x + 40, ButtonMenu[1].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowMonsterpediaEsc()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x - 40, ButtonMenu[1].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowSettings()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, ButtonMenu[2].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowCredits()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, ButtonMenu[3].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowExit()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x - 20, ButtonMenu[4].transform.position.y + 35, WoW.transform.position.z);
    }
    public void FollowExitEsc()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x + 20, ButtonMenu[4].transform.position.y + 35, WoW.transform.position.z);
    }
    #endregion

    #region Gif
    public GameObject[] ImageFire = new GameObject[4];
    private void Start()
    {
        StartCoroutine(FireGif());
    }

    IEnumerator FireGif()
    {
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                ImageFire[i].SetActive(true);
                yield return new WaitForSeconds((float)0.1);
                ImageFire[i].SetActive(false);
                if(i >= 3)
                {
                    i = 0;
                }
            }
        }
    }
    #endregion
}
