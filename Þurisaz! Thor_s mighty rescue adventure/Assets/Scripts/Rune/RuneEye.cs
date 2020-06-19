using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneEye : MonoBehaviour
{

    #region
    //manca bloccare movimento e trapassare alcuni collider

    //public GameObject PlayerContainer;
    //
    //public float sfx;
    //
    //public float speed = 0;
    //float timer = 0, timer2 = 0;
    //Quaternion rotateTo;
    //RaycastHit hit;
    //
    //public GameObject laser;
    //
    //public LineRenderer a;
    //
    //enum Stato { Fermo, Rotazione };
    //Stato statoCorrente = Stato.Fermo;
    //
    //
    //bool isPress = false;
    //
    //void attack()
    //{
    //    bool ray = Physics.Raycast(transform.position, transform.right, out hit, 15f);
    //    if (ray == true)
    //    {
    //        a.SetPosition(1, new Vector3(0, 0, hit.distance));
    //
    //        if (hit.collider.gameObject.tag == "Enemy")
    //            Debug.Log("AHIA!");
    //
    //        if (hit.collider.gameObject.tag != "Enemy")
    //
    //            Debug.Log("Muro");
    //    }
    //
    //    if (ray == false)
    //    {
    //        a.SetPosition(1, new Vector3(0, 0, 15));
    //        Debug.Log("Mancato");
    //    }
    //
    //}
    //
    //void UpdateFermo()
    //{
    //    timer += Time.deltaTime;
    //    if (timer >= 1)
    //    {
    //        laser.SetActive(true);
    //        attack();
    //    }
    //
    //    if (timer >= 2)
    //    {
    //        rotateTo = Quaternion.Euler(0, 90, 0) * transform.rotation;
    //        timer = 0;
    //        statoCorrente = Stato.Rotazione;
    //    }
    //}
    //
    //void UpdateRotazione()
    //{
    //    attack();
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, speed * Time.deltaTime);
    //    if (transform.rotation == rotateTo)
    //    {
    //        timer2 += Time.deltaTime;
    //        if (timer2 >= 1)
    //        {
    //            laser.SetActive(false);
    //            statoCorrente = Stato.Fermo;
    //            timer2 = 0;
    //        }
    //    }
    //}
    //
    //private void Awake()
    //{
    //}
    //private void Start()
    //{
    //    PlayerContainer = GameObject.FindGameObjectWithTag("Player");
    //}
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.L))
    //    {
    //        StartCoroutine(attaccoocchi0());
    //        //switch (statoCorrente)
    //        //{
    //        //    case Stato.Fermo:
    //        //        UpdateFermo();
    //        //        break;
    //        //
    //        //    case Stato.Rotazione:
    //        //        UpdateRotazione();
    //        //        break;
    //        //
    //        //    default:
    //        //        Debug.Log("ERRORE!");
    //        //        break;
    //        //}
    //
    //    }
    //}
    //
    //
    //public IEnumerator attaccoocchi0()
    //{
    //    laser.SetActive(true);
    //    attack();
    //    yield return new WaitForSeconds(1);
    //    laser.SetActive(false);
    //}
    #endregion

    public GameObject[] player = new GameObject[1];
    RaycastHit hit;
    public LineRenderer a;
    public GameObject laser;

    bool isActive = false;

    float timer = 0;

    [Header("DESIGN")]
    [Tooltip("Durata del laser")]
    public float laserTime = 0;
    bool SpellReady = true;
    public float CooldownAttack = 6f;


    private void Start()
    {
        player[0] = GameObject.FindGameObjectWithTag("Player");
    }

    void attack()
    {
        laser.SetActive(true);
        bool ray = Physics.Raycast(transform.position, transform.right, out hit, 15f);

        if (ray == true)
        {
            a.SetPosition(1, new Vector3(0, 0, hit.distance));
            Debug.Log("il nome dell'oggetto colpito è "+hit.transform.gameObject.name);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<EnemyManager>().ColpitoDalLaser = true;
                Debug.Log("AHIA!");
            }

            if (hit.collider.gameObject.tag != "Enemy")
                Debug.Log("Muro");
        }

        if (ray == false)
        {
            a.SetPosition(1, new Vector3(0, 0, 15));
            Debug.Log("Mancato");
        }
    }

    void Update()
    {
        if (InventorySystem.tempIEye == 0)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true || isActive)
            {
                isActive = true;
                attack();
                timer += Time.deltaTime;

                if (timer > laserTime)
                {
                    isActive = false;
                    timer = 0;
                    laser.SetActive(false);
                    Ammo.AmmoEye--;
                    Ammo.NumAmmoEye0.text = Ammo.AmmoEye.ToString();
                }
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
        if (InventorySystem.tempIEye == 1)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)
            {

                isActive = true;
                attack();
                timer += Time.deltaTime;

                if (timer > laserTime)
                {
                    isActive = false;
                    timer = 0;
                    laser.SetActive(false);
                    Ammo.AmmoEye--;
                    Ammo.NumAmmoEye1.text = Ammo.AmmoEye.ToString();
                }
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }

        //if (Input.GetKeyDown(KeyCode.Alpha1) || isActive)
        //{
        //    isActive = true;
        //    attack();
        //    timer += Time.deltaTime;
        //
        //    if (timer > laserTime)
        //    {
        //        isActive = false;
        //        timer = 0;
        //        laser.SetActive(false);
        //    }
        //}
    }


    public IEnumerator cooldown()
    {
        if (InventorySystem.tempIEye == 0)
        {
            //Ammo.RuneRawImageWilloWisp0.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = true;
            player[0].GetComponent<Ammo>().SlotRuneOne.texture = player[0].GetComponent<Ammo>().RuneEyeTexture[1];
            Debug.Log("Entra qui dentro 0");
            yield return new WaitForSeconds(CooldownAttack);
            SpellReady = true;
            player[0].GetComponent<Ammo>().SlotRuneOne.texture = player[0].GetComponent<Ammo>().RuneEyeTexture[0];
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = false;
            //Ammo.RuneRawImageWilloWisp0.enabled = true;
        }
        if (InventorySystem.tempIEye == 1)
        {
            //Ammo.RuneRawImageWilloWisp1.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = true;
            Debug.Log("Entra qui dentro 1");
            player[0].GetComponent<Ammo>().SlotRuneTwo.texture = player[0].GetComponent<Ammo>().RuneEyeTexture[1];
            yield return new WaitForSeconds(CooldownAttack);
            SpellReady = true;
            player[0].GetComponent<Ammo>().SlotRuneTwo.texture = player[0].GetComponent<Ammo>().RuneEyeTexture[0];
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = false;
            //Ammo.RuneRawImageWilloWisp1.enabled = true;
        }
    }

}
