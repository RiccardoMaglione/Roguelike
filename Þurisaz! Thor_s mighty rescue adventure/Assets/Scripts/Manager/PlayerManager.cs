﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Variables Health
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

    public Material MaterialStandardBase;

    public Material MaterialStandard;
    public Material MaterialStandard1;
    public Material MaterialStandard2;

    public Material MaterialStandardHammer;
    public Material MaterialStandardHammer1;
    public Material MaterialStandardHammer2;


    public Material MaterialChange;
    public Renderer GraphicsPlayer;
    public Renderer GraphicsBase;
    public Renderer GraphicsHammer;
    public Renderer GraphicsBelt;
    public static int tempHealth = 6;
    public static int debugHealth;

    public GameObject DebugModeText;
    #endregion
    #region Variables Hammer
    public bool attack = false;
    public GameObject Hammer;
    public static bool isFirstAuto = true;
    public bool isDebugMode = false;
    #endregion
    #region Variables Movement
    public float speed = 5.0f;
    
    public static Vector3 endpos;
    private bool moving = false;
    
    public float acceleration;
    float speedInitial;
    public float friction = 10;
    
    public float timerW = 0f;
    public float timerS = 0f;
    public float timerD = 0f;
    public float timerA = 0f;
    #region GridMovement
    //public float moveSpeed = 3f;
    //private float gridSize = 1f;
    //private enum Orientation
    //{
    //    Horizontal,
    //    Vertical
    //};
    //private Orientation gridOrientation = Orientation.Horizontal;
    //public bool allowDiagonals = false;
    //private bool correctDiagonalSpeed = true;
    //private Vector2 input;
    //private bool isMoving = false;
    //public static Vector3 startPosition;
    ////public static Vector3 endPosition;
    //private float t;
    //private float factor;
    #endregion
    #endregion
    public float sfx;
    public float differentAudio;
    int randSoundHealth;

    static public int EnemyTriggerW = 1;
    static public int EnemyTriggerS = 1;
    static public int EnemyTriggerD = 1;
    static public int EnemyTriggerA = 1;


    static public int ObstacleW = 1;
    static public int ObstacleS = 1;
    static public int ObstacleD = 1;
    static public int ObstacleA = 1;


    public static int Look = 1;

    public static bool Frame = false;

    Material MaterialAlpha;

    float CooldownHammer = 0;
    float CooldownDownHammer = 0.25f;

    public static bool ColpitoPlayer = false;

    static public bool CanMove = true;
    #region Variabili Movemente Definito

    [Header("Nuovo Movimento")]
    public float Delay = 0.1f;
    //public float TempoPrimaDiAndareW = 0f;
    //public float TempoPrimaDiAndareA = 0f;
    //public float TempoPrimaDiAndareS = 0f;
    //public float TempoPrimaDiAndareD = 0f;
    //public bool ResetT = false;


    static public int DirectionW = 0;
    static public int DirectionA = 0;
    static public int DirectionS = 0;
    static public int DirectionD = 0;

    #endregion
    public GameObject ExplosionEggCracker;
    private void OnTriggerEnter(Collider other)
    {
        #region Trigger Health
        if ((other.gameObject.tag == "Shot" || other.gameObject.tag == "Scream" || other.gameObject.tag == "Stalactite" || other.gameObject.tag == "Spike" || other.gameObject.tag == "Egg" || other.gameObject.tag == "Eggcracker") && damage == true)
        {
            if (other.gameObject.tag == "Shot" || other.gameObject.tag == "Scream" || other.gameObject.tag == "Stalactite" || other.gameObject.tag == "Egg" || other.gameObject.tag == "Eggcracker")
            {
                if(other.gameObject.tag == "Egg" || other.gameObject.tag == "Eggcracker")
                {
                    GameObject GoExplosion = Instantiate(ExplosionEggCracker, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), transform.rotation);
                    Destroy(GoExplosion,1);
                }
                Destroy(other.gameObject);
            }
            randSoundHealth = Random.Range(1, 4);
            if (randSoundHealth == 1)
                FindObjectOfType<AudioManager>().Play("ThorDamage1", sfx);

            if (randSoundHealth == 2)
                FindObjectOfType<AudioManager>().Play("ThorDamage2", sfx);
            
            if (randSoundHealth == 3)
                FindObjectOfType<AudioManager>().Play("ThorDamage3", sfx);
                                  
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
        #endregion
        #region Trigger for Attack Valravn
    if (other.gameObject.name == "WallWFinale")
    {
        endpos = new Vector3((int)transform.position.x, transform.position.y, (int)other.transform.position.z - 1);
    }
    if (other.gameObject.name == "WallSFinale")
    {
        endpos = new Vector3((int)transform.position.x, transform.position.y, (int)other.transform.position.z + 1f);
    }
    if (other.gameObject.name == "WallDFinale")
    {
        endpos = new Vector3((int)other.transform.position.x - 1f, transform.position.y, (int)transform.position.z);
    }
    if (other.gameObject.name == "WallAFinale")
    {
        endpos = new Vector3((int)other.transform.position.x + 1f, transform.position.y, (int)transform.position.z);
    }
        #endregion
    }

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");
        differentAudio = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Start()
    {
        #region
        Scene CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == "ThirdLevel")
        {
            if(debugHealth > 6)
            {
                isDebugMode = true;
                health = 2147483647;
                DebugModeText.SetActive(true);
            }
            else
            {
                health = tempHealth;
            }
        }
        
        #endregion
        #region Start Hammer
        Hammer.gameObject.tag = "NotWeapon";
        #endregion
        #region Start Movement
        endpos = transform.position;
        speedInitial = speed;
        #endregion
    }
    private void Update()
    {
        if(ColpitoPlayer == true && damage == true)
        {
            health--;
            ColpitoPlayer = false;
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


        //Non servono più i muri intorno ai nemici
        #region Detect Enemy
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right*1.5f, out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.right*1, Color.green);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if(transform.right == Vector3.forward)
                    {
                        Debug.Log("Valore Enemy trigger davanti" + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS + EnemyTriggerA);
                        EnemyTriggerW = 0;
                    }
                    if (transform.right == Vector3.back)
                    {
                        Debug.Log("Valore Enemy trigger dietro" + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS + EnemyTriggerA);
                        EnemyTriggerS = 0;
                    }
                    if (transform.right == Vector3.right)
                    {
                        Debug.Log("Valore Enemy trigger destra" + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS + EnemyTriggerA);
                        EnemyTriggerD = 0;
                    }
                    if (transform.right == Vector3.left)
                    {
                        Debug.Log("Valore Enemy trigger sinistra" + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS + EnemyTriggerA);
                        EnemyTriggerA = 0;
                    }

                    Debug.Log("Valore Enemy trigger " + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS + EnemyTriggerA);
                    Debug.Log("Non mi fa passare");
                }
            }
        }
        else
        {
            EnemyTriggerW = 1;
            EnemyTriggerS = 1;
            EnemyTriggerD = 1;
            EnemyTriggerA = 1;
            Debug.Log("Valore Enemy trigger " + EnemyTriggerW + EnemyTriggerD + EnemyTriggerS +EnemyTriggerA);
            Debug.Log("Fammi Passare");
        }
        #endregion

        #region Detect Obstacle
        RaycastHit hitOb;
        if (Physics.Raycast(transform.position, transform.right * 1.5f, out hitOb, 1))
        {
            Debug.DrawRay(transform.position, transform.right * 1, Color.green);
            if (hitOb.collider)
            {
                if (hitOb.collider.gameObject.tag == "Obstacle")
                {
                    if (transform.right == Vector3.forward)
                    {
                        Debug.Log("Valore Enemy trigger davanti" + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
                        ObstacleW = 0;
                    }
                    if (transform.right == Vector3.back)
                    {
                        Debug.Log("Valore Enemy trigger dietro" + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
                        ObstacleS = 0;
                    }
                    if (transform.right == Vector3.right)
                    {
                        Debug.Log("Valore Enemy trigger destra" + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
                        ObstacleD = 0;
                    }
                    if (transform.right == Vector3.left)
                    {
                        Debug.Log("Valore Enemy trigger sinistra" + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
                        ObstacleA = 0;
                    }

                    Debug.Log("Valore Enemy trigger " + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
                    Debug.Log("Non mi fa passare");
                }
            }
        }
        else
        {
            ObstacleW = 1;
            ObstacleS = 1;
            ObstacleD = 1;
            ObstacleA = 1;
            Debug.Log("Valore Enemy trigger " + ObstacleW + ObstacleD + ObstacleS + ObstacleA);
            Debug.Log("Fammi Passare");
        }
        #endregion


        #region Update Health
        if (Input.GetKeyDown(KeyCode.G) && isDebugMode == false)
        {
            tempHealth = health;
            health = 2147483647;
            debugHealth = 2147483647;
            DebugModeText.SetActive(true);
            isDebugMode = true;
        }
        if (Input.GetKeyDown(KeyCode.H) && isDebugMode == true)
        {
            health = tempHealth;
            debugHealth = tempHealth;
            DebugModeText.SetActive(false);
            isDebugMode = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Stop("FirstLevelOST");
            FindObjectOfType<AudioManager>().Play("GameOverSound", differentAudio);
            GameManager.GoToGameOver();
        }
        if (health == 6)
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
        #endregion
        #region Update Hammer
        //Attack();


        if (Input.GetKeyDown(KeyCode.Space) && attack == false)
        {
            StartCoroutine(HammerAttack());
        }




        #endregion

        #region Update Movement
        if(CanMove == true)
        {
            #region Move Vecchio
            //        float v = Input.GetAxis("Vertical");
            //        float h = Input.GetAxis("Horizontal");
            //        if (moving && (transform.position == endpos))
            //        {
            //            moving = false;
            //            speed = speedInitial;
            //        }
            //        #region Movement W
            //    if (!moving && (Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))      //w
            //    {
            //        transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            //        timerW += Time.deltaTime;
            //        //timerS = 0; timerA = 0; timerD = 0;
            //        Look = 1;
            //        DirectionA = 0;
            //        DirectionS = 0;
            //        DirectionD = 0;
            //        DirectionW = 1;
            //        if (timerW > Delay)
            //        {   
            //            moving = true;
            //            speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(v);
            //            endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.forward * WallTrigger.WallW * EnemyTriggerW * ObstacleW;
            //        } 
            //    }
            //        #endregion
            //        #region Movement S
            //        if (!moving && (Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))     //s
            //        {
            //         transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            //         timerS += Time.deltaTime;
            //         //timerW = 0; timerA = 0; timerD = 0;
            //         Look = 2;
            //         DirectionW = 0;
            //         DirectionA = 0;
            //         DirectionS = 1;
            //         DirectionD = 0;
            //        if (timerS > Delay)
            //        {
            //            moving = true;
            //            speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(v);
            //            endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.back * WallTrigger.WallS * EnemyTriggerS * ObstacleS;
            //        }
            //    }
            //        #endregion
            //        #region Movement A
            //        if (!moving && (Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))     //a
            //    {
            //         transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            //         timerA += Time.deltaTime;
            //         //timerW = 0; timerS = 0; timerD = 0;
            //         Look = 3;
            //         DirectionW = 0;
            //         DirectionA = 1;
            //         DirectionS = 0;
            //         DirectionD = 0;
            //        if (timerA > Delay)
            //         {
            //             moving = true;
            //             speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(h);
            //             endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.left * WallTrigger.WallA * EnemyTriggerA * ObstacleA;
            //         }
            //    }
            //        #endregion
            //        #region Movement D
            //        if (!moving && (Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))  //d
            //    {
            //        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            //        timerD += Time.deltaTime;
            //        //timerW = 0; timerS = 0; timerA = 0;
            //        Look = 4;
            //        DirectionW = 0;
            //        DirectionS = 0;
            //        DirectionA = 0;
            //        DirectionD = 1;
            //        if (timerD > Delay)
            //        {
            //            moving = true;
            //            speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(h);
            //            endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.right * WallTrigger.WallD * EnemyTriggerD * ObstacleD;
            //        }
            //    }
            //        #endregion
            #endregion
            #region Move Nuovo
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            if (moving && (transform.position == endpos))
            {
                moving = false;
            }
            #region Movement W
            if (!moving && (Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))      //w
            {
                speed = speedInitial;
                transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
                timerW += Time.deltaTime;
                Look = 1;
                DirectionA = 0;
                DirectionS = 0;
                DirectionD = 0;
                DirectionW = 1;
                if (timerW > Delay)
                {
                    if ((Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))
                    {
                        timerW = 0.1f; timerS = 0; timerA = 0; timerD = 0;
                    }
                    if ((Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))
                    {
                        timerW = 0; timerA = 0; timerD = 0; timerS = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))
                    {
                        timerW = 0; timerS = 0; timerA = 0; timerD = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))
                    {
                        timerW = 0; timerS = 0; timerD = 0; timerA = 0.1f;
                    }
                    moving = true;
                    speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(v);
                    endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.forward * WallTrigger.WallW * EnemyTriggerW * ObstacleW;
                } 
            }
            #endregion
            #region Movement S
            if (!moving && (Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))     //s
            {
                speed = speedInitial;
                transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
                timerS += Time.deltaTime;
                Look = 2;
                DirectionW = 0;
                DirectionA = 0;
                DirectionS = 1;
                DirectionD = 0;
                if (timerS > Delay)
                {
                    if ((Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))
                    {
                        timerW = 0.1f; timerS = 0; timerA = 0; timerD = 0;
                    }
                    if ((Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))
                    {
                        timerW = 0; timerA = 0; timerD = 0; timerS = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))
                    {
                        timerW = 0; timerS = 0; timerA = 0; timerD = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))
                    {
                        timerW = 0; timerS = 0; timerD = 0; timerA = 0.1f;
                    }
                    moving = true;
                    speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(v);
                    endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.back * WallTrigger.WallS * EnemyTriggerS * ObstacleS;
                }
            }
            #endregion
            #region Movement A
            if (!moving && (Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))     //a
            {
                speed = speedInitial;
                transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
                timerA += Time.deltaTime;
                Look = 3;
                DirectionW = 0;
                DirectionA = 1;
                DirectionS = 0;
                DirectionD = 0;
                if (timerA > Delay)
                {
                    if ((Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))
                    {
                        timerW = 0.1f; timerS = 0; timerA = 0; timerD = 0;
                    }
                    if ((Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))
                    {
                        timerW = 0; timerA = 0; timerD = 0; timerS = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))
                    {
                        timerW = 0; timerS = 0; timerA = 0; timerD = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))
                    {
                        timerW = 0; timerS = 0; timerD = 0; timerA = 0.1f;
                    }
                    moving = true;
                    speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(h);
                    endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.left * WallTrigger.WallA * EnemyTriggerA * ObstacleA;
                }
            }
            #endregion
            #region Movement D
            if (!moving && (Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))  //d
            {
                speed = speedInitial;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
                timerD += Time.deltaTime;
                Look = 4;
                DirectionW = 0;
                DirectionS = 0;
                DirectionA = 0;
                DirectionD = 1;
                if (timerD > Delay)
                {
                    if ((Input.GetKey(ControlsManager.CM.forward) || Input.GetAxis("Vertical") > 0))
                    {
                        timerW = 0.1f; timerS = 0; timerA = 0; timerD = 0;
                    }
                    if ((Input.GetKey(ControlsManager.CM.backward) || Input.GetAxis("Vertical") < 0))
                    {
                        timerW = 0; timerA = 0; timerD = 0; timerS = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.right) || Input.GetAxis("Horizontal") > 0))
                    {
                        timerW = 0; timerS = 0; timerA = 0; timerD = 0.1f;
                    }
                    if ((Input.GetKey(ControlsManager.CM.left) || Input.GetAxis("Horizontal") < 0))
                    {
                        timerW = 0; timerS = 0; timerD = 0; timerA = 0.1f;
                    }
                    moving = true;
                    speed += (acceleration - speed * friction) * Time.deltaTime * -Mathf.Abs(h);
                    endpos = new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z) + Vector3.right * WallTrigger.WallD * EnemyTriggerD * ObstacleD;
                }
            }
            #endregion
            #endregion
            transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
            endpos = new Vector3((int)endpos.x, endpos.y, (int)endpos.z);
        }
        #endregion
    }

    #region Function Hammer
    void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && attack == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit", sfx);
            Hammer.transform.Rotate(0, 0, -75);
            Hammer.gameObject.tag = "Weapon";
            attack = true;
        }
        else if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && attack == true)
        {
            Hammer.transform.Rotate(0, 0, 75);
            Hammer.gameObject.tag = "NotWeapon";
            attack = false;
        }
    }
    #endregion

    #region IEnumerator Health
    public IEnumerator flash()
    {
        Material[] matArrayStandard = GraphicsPlayer.materials;
        matArrayStandard[0] = MaterialStandard;
        matArrayStandard[1] = MaterialStandard1;
        matArrayStandard[2] = MaterialStandard2;
        Material[] matArrayChange = GraphicsPlayer.materials;
        matArrayChange[0] = MaterialChange;
        matArrayChange[1] = MaterialChange;
        matArrayChange[2] = MaterialChange;

        Material[] matArrayStandardBelt = GraphicsBelt.materials;
        matArrayStandardBelt[0] = MaterialStandard;
        matArrayStandardBelt[1] = MaterialStandard1;
        matArrayStandardBelt[2] = MaterialStandard2;
        Material[] matArrayChangeBelt = GraphicsBelt.materials;
        matArrayChangeBelt[0] = MaterialChange;
        matArrayChangeBelt[1] = MaterialChange;
        matArrayChangeBelt[2] = MaterialChange;

        Material[] matArrayStandardHammer = GraphicsHammer.materials;
        matArrayStandardHammer[0] = MaterialStandardHammer;
        matArrayStandardHammer[1] = MaterialStandardHammer1;
        matArrayStandardHammer[2] = MaterialStandardHammer2;
        Material[] matArrayChangeHammer = GraphicsHammer.materials;
        matArrayChangeHammer[0] = MaterialChange;
        matArrayChangeHammer[1] = MaterialChange;
        matArrayChangeHammer[2] = MaterialChange;





        for (int i = 0; i < 5; i++)
        {

            GraphicsPlayer.materials = matArrayStandard;
            GraphicsHammer.materials = matArrayStandardHammer;
            GraphicsBelt.materials = matArrayStandardBelt;
            GraphicsBase.material = MaterialStandardBase;
            yield return new WaitForSeconds(0.2f);
            GraphicsPlayer.materials = matArrayChangeHammer;
            GraphicsHammer.materials = matArrayChange;
            GraphicsBelt.materials = matArrayChangeBelt;
            GraphicsBase.material = MaterialChange;
            //GraphicsPlayer.material = MaterialChange;
            yield return new WaitForSeconds(0.2f);
        }
        GraphicsPlayer.materials = matArrayStandard;
        GraphicsHammer.materials = matArrayStandardHammer;
        GraphicsBelt.materials = matArrayStandardBelt;
        GraphicsBase.material = MaterialStandardBase;
    }

    public IEnumerator invincibility()
    {
        yield return new WaitForSeconds(2);
        damage = true;
    }
    #endregion

    IEnumerator HammerAttack()
    {
        //yield return new WaitForSeconds(0.5f);
        if (attack == false)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit", sfx);
            Hammer.transform.Rotate(0, 0, -75);
            Hammer.gameObject.tag = "Weapon";
            attack = true;
        }
        yield return new WaitForSeconds(CooldownDownHammer);
        if (attack == true)
        {
            Hammer.transform.Rotate(0, 0, 75);
            Hammer.gameObject.tag = "NotWeapon";
            yield return new WaitForSeconds(CooldownHammer);
            attack = false;
        }
    }
}