using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> bossItems = new List<GameObject>();
    public GameObject player;

    private void OnTriggerEnter(Collider other)                                     //Raccolta rune
    {
        if (items.Count < 2 && other.tag == "RuneWow")                             //Raccolta rune nemici base
        {
            items.Add(other.gameObject);
            //other.gameObject.transform.position = transform.localPosition + Vector3.up * items.Count;
            //other.transform.parent = player.transform;
        }
        if (items.Count < 2 && other.tag == "RuneValvran")                             //Raccolta rune nemici base
        {
            items.Add(other.gameObject);
            //other.gameObject.transform.position = transform.localPosition + Vector3.up * items.Count;
            //other.transform.parent = player.transform;
        }

        if (bossItems.Count < 1 && other.tag == "RuneGammur")                         //Raccolta rune Boss  
        {
            //other.gameObject.transform.position = transform.localPosition + Vector3.up * 3;
            bossItems.Add(other.gameObject);
            //other.transform.parent = player.transform;
        }
    }

    private void OnTriggerStay(Collider other)                                      //Scambio rune
    {
        if (items.Count == 2 && other.tag != "RuneGammur")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {              
                items.Insert(0, other.gameObject);
                items[1].transform.position = transform.localPosition;
                items[1].transform.parent = null;
                items.RemoveAt(1);               
                items[0].transform.position = transform.localPosition + Vector3.up;                            
                other.transform.parent = player.transform;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                items.Add(other.gameObject);
                items[1].transform.position = transform.localPosition;
                items[1].transform.parent = null;
                items.RemoveAt(1);
                items[1].transform.position = transform.localPosition + Vector3.up * items.Count;
                other.transform.parent = player.transform;
            }
        }

        if (bossItems.Count == 1  && other.tag == "BossRune")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                bossItems[0].transform.parent = null;
                bossItems[0].transform.position = transform.localPosition;
                bossItems.Add(other.gameObject);
                other.gameObject.transform.position = transform.localPosition + Vector3.up * 3;
                other.transform.parent = player.transform;
                bossItems.RemoveAt(0);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
