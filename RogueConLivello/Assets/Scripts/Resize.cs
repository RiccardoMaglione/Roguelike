using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
     public void OnMouseEnter()
     {
         transform.localScale += new Vector3(0.25f, 0.25f, 0.25f); //adjust these values as you see fit
     }

     public void OnMouseExit()
     {
         transform.localScale = new Vector3(1, 1, 1);  // assuming you want it to return to its original size when your mouse leaves it.
     }
}
