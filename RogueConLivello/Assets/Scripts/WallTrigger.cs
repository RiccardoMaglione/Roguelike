using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public static int WallW = 1;
    public static int WallS = 1;
    public static int WallA = 1;
    public static int WallD = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "WallW")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (gameObject.tag == "WallS")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (gameObject.tag == "WallA")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (gameObject.tag == "WallD")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "WallW")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 1;
            }
        }
        if (gameObject.tag == "WallS")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (gameObject.tag == "WallA")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (gameObject.tag == "WallD")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
    }
}
