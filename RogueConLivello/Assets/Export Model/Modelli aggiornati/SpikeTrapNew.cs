using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapNew : MonoBehaviour

{
    public Transform SpikePos;
    public GameObject SpikeNormal;
    public GameObject SpikeBlood;
    public GameObject SpikeBaseBlood;

    public float upSpeed = 30;
    public float downSpeed = 1;

    private bool open = false;
    static public bool isRune = true;
    
    private void Start()
    {
        SpikeBaseBlood.SetActive(false);
        SpikeBlood.SetActive(false);
    }

    void Update()
    {
        if (open)
        {
            SpikePos.position = Vector3.Lerp(SpikePos.position, new Vector3(SpikePos.transform.position.x, 0, SpikePos.transform.position.z), Time.deltaTime * upSpeed);
        }
        else
        {
            SpikePos.position = Vector3.Lerp(SpikePos.position, new Vector3(SpikePos.transform.position.x, -1, SpikePos.transform.position.z), Time.deltaTime * downSpeed);
        }
        Collider[] RuneOnTrap = Physics.OverlapSphere(transform.position, 1);
        foreach (Collider other in RuneOnTrap)
        {
            if (other.gameObject.tag == "RuneWow")
            {
                SpikeDown();
                SpikeNormal.SetActive(true);
                SpikeBlood.SetActive(false);
                SpikeBaseBlood.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            SpikeUp();
            SpikeNormal.SetActive(false);
            SpikeBlood.SetActive(true);
            SpikeBaseBlood.SetActive(true);           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "RuneWow")
        {
            SpikeDown();
            SpikeNormal.SetActive(true);
            SpikeBlood.SetActive(false);
            SpikeBaseBlood.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            SpikeDown();
            SpikeNormal.SetActive(true);
            SpikeBlood.SetActive(false);
            SpikeBaseBlood.SetActive(false);
        }
    }


    public void SpikeUp()
    {
        open = true;
    }

    public void SpikeDown()
    {
        open = false;
    }
}