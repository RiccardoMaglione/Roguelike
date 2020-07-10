using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternEye : MonoBehaviour
{
    public GameObject AnimationSheet;
    public GameObject EyeContainer;
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    bool isFirstActivate = true;

    public float sfx;

    public float speed = 0;
    float timer = 0, timer2 = 0;
    Quaternion rotateTo;
    RaycastHit hit;

    public GameObject laser;

    public LineRenderer a;

    enum Stato { Fermo, Rotazione };
    Stato statoCorrente = Stato.Fermo;

    void attack()
    {
        
        bool ray = Physics.Raycast(transform.position, transform.forward, out hit, 15f);

        if (ray == true)
        {
            a.SetPosition(1, new Vector3(0, 0, hit.distance));

            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerManager.ColpitoPlayer = true;
            }
        }

        if (ray == false)
        {
            a.SetPosition(1, new Vector3(0, 0, 15));
        }
        
    }

    void UpdateFermo()
    {
        AnimationSheet.SetActive(true);
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            laser.SetActive(true);
            attack();         
        }

        if (timer >= 2)
        {
            AnimationSheet.SetActive(false);
            rotateTo = Quaternion.Euler(0, 90, 0) * transform.rotation;
            timer = 0;
            statoCorrente = Stato.Rotazione;
        }
    }

    void UpdateRotazione()
    {
        attack();
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, speed * Time.deltaTime);
        if (transform.rotation == rotateTo)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 1)
            {
                laser.SetActive(false);
                statoCorrente = Stato.Fermo;
                timer2 = 0;
            }
        }
    }

    private void Start()
    {
        AnimationSheet.SetActive(false);
    }

    void Update()
    {
        switch (statoCorrente)
        {
            case Stato.Fermo:
                UpdateFermo();
                break;

            case Stato.Rotazione:
                UpdateRotazione();
                break;

            default:
                Debug.Log("ERRORE!");
                break;
        }
    }
    public IEnumerator flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(0.5f);
        GraphicsBase.material = MaterialStandard;
    }
}
