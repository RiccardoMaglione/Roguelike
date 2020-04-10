using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int health;

    public GameObject EmptyHeart1;
    public GameObject EmptyHeart2;
    public GameObject EmptyHeart3;
    public GameObject HalfHeart1;
    public GameObject HalfHeart2;
    public GameObject HalfHeart3;
    public GameObject FullHeart1;
    public GameObject FullHeart2;
    public GameObject FullHeart3;

    public float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Shot" || other.gameObject.tag == "Scream" || other.gameObject.tag == "Stalactite") && timer == 0)
        { 
            Destroy(other.gameObject);
            health--;
            
            if (health == 5)
            {
                FullHeart3.SetActive(false);
                HalfHeart3.SetActive(true);
            }
            if (health == 4)
            {
                HalfHeart3.SetActive(false);
                EmptyHeart3.SetActive(true);
            }
            if (health == 3)
            {
                FullHeart2.SetActive(false);
                HalfHeart2.SetActive(true);
            }
            if (health == 2)
            {
                HalfHeart2.SetActive(false);
                EmptyHeart2.SetActive(true);
            }
            if (health == 1)
            {
                FullHeart1.SetActive(false);
                HalfHeart1.SetActive(true);
            }
            if (health == 0)
            {
                HalfHeart1.SetActive(false);
                EmptyHeart1.SetActive(true);
            }
            timer = timer + Time.deltaTime;
        }
        if (other.gameObject.tag == "Rune")
        {

        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
        if(health == 6)
        {
            FullHeart1.SetActive(true);
            FullHeart2.SetActive(true);
            FullHeart3.SetActive(true);

            HalfHeart1.SetActive(false);
            HalfHeart2.SetActive(false);
            HalfHeart3.SetActive(false);

            EmptyHeart1.SetActive(false);
            EmptyHeart2.SetActive(false);
            EmptyHeart3.SetActive(false);
        }
        if (timer != 0)
            timer = timer + Time.deltaTime;

        if (timer >= 0.5f)
            timer = 0;   
    }
}