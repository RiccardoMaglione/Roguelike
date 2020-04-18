using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttackGammurOne : MonoBehaviour
{
    public GameObject ScreamPart;
    public GameObject[] Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Scream());
        }
    }
    public IEnumerator Scream()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds((float)2f);
            GameObject newShot1 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            newShot1.tag = "ShotPlayer";
            GameObject newShot2 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            newShot2.tag = "ShotPlayer";
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot3 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -2f), Player[0].transform.rotation);
            newShot3.tag = "ShotPlayer";
            GameObject newShot4 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 3f), Player[0].transform.rotation);
            newShot4.tag = "ShotPlayer";
            GameObject newShot5 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -3f), Player[0].transform.rotation);
            newShot5.tag = "ShotPlayer";
            GameObject newShot6 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 2f), Player[0].transform.rotation);
            newShot6.tag = "ShotPlayer";
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot7 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 4f), Player[0].transform.rotation);
            newShot7.tag = "ShotPlayer";
            GameObject newShot8 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -4f), Player[0].transform.rotation);
            newShot8.tag = "ShotPlayer";
            GameObject newShot9 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * 5f), Player[0].transform.rotation);
            newShot9.tag = "ShotPlayer";
            GameObject newShot10 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 2f) + (Player[0].transform.forward * -5f), Player[0].transform.rotation);
            newShot10.tag = "ShotPlayer";
            yield return new WaitForSeconds((float)0.2f);
            GameObject newShot11 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * 1f), Player[0].transform.rotation);
            newShot11.tag = "ShotPlayer";
            GameObject newShot12 = Instantiate(ScreamPart, Player[0].transform.position + (Player[0].transform.right * 3f) + (Player[0].transform.forward * -1f), Player[0].transform.rotation);
            newShot12.tag = "ShotPlayer";
            yield return new WaitForSeconds((float)0.2f);
        }
    }
}