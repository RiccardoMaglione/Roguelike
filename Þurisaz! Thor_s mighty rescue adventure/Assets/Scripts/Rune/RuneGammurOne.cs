using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuneGammurOne : MonoBehaviour
{
    public GameObject ScreamPart;
    public GameObject[] Player;
    bool SpellReady = true;
    RawImage GammurCooldownOne;

    public GameObject shadow;

    Scene CurrentScene;




    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        if (CurrentScene.name == "FirstLevel")
        {
            GammurCooldownOne = GameObject.Find("RuneGammur1RawImageCooldown").GetComponent<RawImage>();
            GammurCooldownOne.enabled = false;
        }
        if (CurrentScene.name == "ThirdLevel")
        {
            GammurCooldownOne = GameObject.Find("RuneGammur1RawImageCooldown").GetComponent<RawImage>();
            GammurCooldownOne.enabled = false;
        }
    }
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && SpellReady == true)
        {
            StartCoroutine(Scream());
            SpellReady = false;
            StartCoroutine(cooldown());
        }
    }
    public IEnumerator Scream()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds((float)2f);
            GameObject newShot1 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            newShot1.tag = "ShotPlayer";
            GameObject shadow1 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            shadow1.tag = "ShotPlayer";
            shadow1.transform.parent = newShot1.transform;
            GameObject newShot2 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            newShot2.tag = "ShotPlayer";
            GameObject shadow2 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            shadow2.tag = "ShotPlayer";
            shadow2.transform.parent = newShot2.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot3 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -2f), Player[0].transform.rotation);
            newShot3.tag = "ShotPlayer";
            GameObject shadow3 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -2f), Player[0].transform.rotation);
            shadow3.tag = "ShotPlayer";
            shadow3.transform.parent = newShot3.transform;
            GameObject newShot4 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 3f), Player[0].transform.rotation);
            newShot4.tag = "ShotPlayer";
            GameObject shadow4 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 3f), Player[0].transform.rotation);
            shadow4.tag = "ShotPlayer";
            shadow4.transform.parent = newShot4.transform;
            GameObject newShot5 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -3f), Player[0].transform.rotation);
            newShot5.tag = "ShotPlayer";
            GameObject shadow5 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -3f), Player[0].transform.rotation);
            shadow5.tag = "ShotPlayer";
            shadow5.transform.parent = newShot5.transform;
            GameObject newShot6 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 2f), Player[0].transform.rotation);
            newShot6.tag = "ShotPlayer";
            GameObject shadow6 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 2f), Player[0].transform.rotation);
            shadow6.tag = "ShotPlayer";
            shadow6.transform.parent = newShot6.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot7 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 4f), Player[0].transform.rotation);
            newShot7.tag = "ShotPlayer";
            GameObject shadow7 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 4f), Player[0].transform.rotation);
            shadow7.tag = "ShotPlayer";
            shadow7.transform.parent = newShot7.transform;
            GameObject newShot8 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -4f), Player[0].transform.rotation);
            newShot8.tag = "ShotPlayer";
            GameObject shadow8 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -4f), Player[0].transform.rotation);
            shadow8.tag = "ShotPlayer";
            shadow8.transform.parent = newShot8.transform;
            GameObject newShot9 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 5f), Player[0].transform.rotation);
            newShot9.tag = "ShotPlayer";
            GameObject shadow9 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 5f), Player[0].transform.rotation);
            shadow9.tag = "ShotPlayer";
            shadow9.transform.parent = newShot3.transform;
            GameObject newShot10 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -5f), Player[0].transform.rotation);
            newShot10.tag = "ShotPlayer";
            GameObject shadow10 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -5f), Player[0].transform.rotation);
            shadow10.tag = "ShotPlayer";
            shadow10.transform.parent = newShot3.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot11 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            newShot11.tag = "ShotPlayer";
            GameObject shadow11 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            shadow11.tag = "ShotPlayer";
            shadow11.transform.parent = newShot11.transform;
            GameObject newShot12 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            newShot12.tag = "ShotPlayer";
            GameObject shadow12 = Instantiate(shadow, new Vector3(Player[0].transform.localPosition.x, 0.1f, Player[0].transform.localPosition.z) + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            shadow12.tag = "ShotPlayer";
            shadow12.transform.parent = newShot3.transform;
            yield return new WaitForSeconds((float)0.2f);
        }
    }
    public IEnumerator cooldown()
    {
        GammurCooldownOne.enabled = true;
        yield return new WaitForSeconds(15);
        SpellReady = true;
        GammurCooldownOne.enabled = false;
    }
}