using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowImage : MonoBehaviour
{
    public GameObject WoW;
    public Button play;
    public Button monsterpedia;
    public Button settings;
    public Button credits;
    public Button exit;
    public void FollowPlay()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, play.transform.position.y+35, WoW.transform.position.z);
    }
    public void FollowMonsterpedia()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, monsterpedia.transform.position.y+35, WoW.transform.position.z);
    }
    public void FollowSettings()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, settings.transform.position.y+35, WoW.transform.position.z);
    }
    public void FollowCredits()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, credits.transform.position.y+35, WoW.transform.position.z);
    }
    public void FollowExit()
    {
        WoW.transform.position = new Vector3(WoW.transform.position.x, exit.transform.position.y+35, WoW.transform.position.z);
    }

}
