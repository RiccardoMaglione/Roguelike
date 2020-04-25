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

    bool damage = true;
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsPlayer;
    int tempHealth;

    public GameObject DebugModeText;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Shot" || other.gameObject.tag == "Scream" || other.gameObject.tag == "Stalactite" || other.gameObject.tag == "Spike" || other.gameObject.tag == "Egg" || other.gameObject.tag == "Eggcracker") && damage == true)
        { 
            if(other.gameObject.tag == "Shot" || other.gameObject.tag == "Scream" || other.gameObject.tag == "Stalactite" || other.gameObject.tag == "Egg" || other.gameObject.tag == "Eggcracker")
            {
                Destroy(other.gameObject);
            }

            health--;
            damage = false;
            StartCoroutine(invincibility());
            StartCoroutine(flash());
            
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
        }
        if (other.gameObject.tag == "Rune")
        {

        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            tempHealth = health;
            health = 2147483647;
            DebugModeText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = tempHealth;
            DebugModeText.SetActive(false);
        }

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
    }

    public IEnumerator flash()
    {
        for (int i = 0; i < 5; i++)
        {
            GraphicsPlayer.material = MaterialStandard;
            yield return new WaitForSeconds(0.2f);
            GraphicsPlayer.material = MaterialChange;
            yield return new WaitForSeconds(0.2f);
        }
        GraphicsPlayer.material = MaterialStandard;
    }

    public IEnumerator invincibility()
    {
        yield return new WaitForSeconds(2);
        damage = true;
    }
}