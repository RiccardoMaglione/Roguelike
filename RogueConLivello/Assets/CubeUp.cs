using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUp : MonoBehaviour

{
    public Transform CubePos;

    public Vector3 ClosedPosition = new Vector3(0, 3f, 0);
    public Vector3 OpenPosition = new Vector3(0, 8f, 0);

    public float openspeed = 5;

    private bool open = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            CubePos.position = Vector3.Lerp(CubePos.position, OpenPosition, Time.deltaTime * openspeed);
        }
        else
        {
            CubePos.position = Vector3.Lerp(CubePos.position, ClosedPosition, Time.deltaTime * openspeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ClosedDoor();
        }
    }

    public void OpenDoor()
    {
        open = true;
    }

    public void ClosedDoor()
    {
        open = false;
    }
}