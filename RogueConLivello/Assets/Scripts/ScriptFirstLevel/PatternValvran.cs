using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternValvran : MonoBehaviour
{
    public GameObject PeckReference;
    public GameObject ValvranContainer;
    bool s1 = false, s2 = false, s3 = false;
    float timer = 0;
    Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(target);
        timer = timer + Time.deltaTime;
        if (timer >= 2 && s1 == false && s2 == false && s3 == false)
        {
            Peck1();
            s1 = true;
        }

        if (timer >= 2.3f && s1 == true && s2 == false && s3 == false)
        {
            Peck2();
            s2 = true;
        }

        if (timer >= 2.6 && s1 == true && s2 == true && s3 == false)
        {
            Peck3();
            s3 = true;
            timer = 0;
            s1 = false;
            s2 = false;
            s3 = false;
        }
    }

    void Peck1()
    {
        GameObject newShot1 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
        Destroy(newShot1, 0.5f);
    }
    void Peck2()
    {
        GameObject newShot2 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation);
        Destroy(newShot2, 0.5f);
    }
    void Peck3()
    {
        GameObject newShot3 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));
        Destroy(newShot3, 0.5f);
    }
}
