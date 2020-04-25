using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneAttackGammurThree : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject ChickenMinion;
    bool SpellReady = true;
    RawImage GammurCooldownThree;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        GammurCooldownThree = GameObject.Find("RuneGammur3RawImageCooldown").GetComponent<RawImage>();
        GammurCooldownThree.enabled = false;
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && SpellReady == true)
        {
            SpawnMinion();
            SpellReady = false;
            StartCoroutine(cooldown());
        }
    }

    void SpawnMinion()
    {
        float radius = 3f;
        for (int i = 0; i < 3; i++)
        {
            float angle = i * Mathf.PI * 2f / 3;
            Vector3 newPos = new Vector3(Player[0].transform.position.x + Mathf.Cos(angle) * radius, Player[0].transform.position.y, Player[0].transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go1 = Instantiate(ChickenMinion, newPos, Quaternion.identity);
            go1.tag = "EggcrackerPlayer";
            //go1.transform.SetParent(Player[0].transform);
            go1.AddComponent<MinionLookAtClosest>();
        }
    }
    public IEnumerator cooldown()
    {
        GammurCooldownThree.enabled = true;
        yield return new WaitForSeconds(20);
        SpellReady = true;
        GammurCooldownThree.enabled = false;
    }
}