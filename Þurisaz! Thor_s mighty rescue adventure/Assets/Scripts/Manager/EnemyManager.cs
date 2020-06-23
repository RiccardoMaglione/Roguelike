using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    #region Variables
    public GameObject Hole;

    [Header("Reference for Various Runes")]
    public GameObject RuneReference;
    //public GameObject RuneBossGammur;
    public GameObject RuneBossGammur1;
    public GameObject RuneBossGammur2;
    public GameObject RuneBossGammur3;
    public GameObject Player;

    [Header("Reference for Various Materials")]
    public Material MaterialStandardEnemy;
    public Material MaterialStandardBase;
    public Material MaterialChange;
    public Renderer GraphicsEnemy;
    public Renderer GraphicsBase;

    [Header("Reference for Various Colliders")]
    public GameObject BossContainer;
    public GameObject DoorCollider;
    public GameObject PrecedentCollider;
    public GameObject AltoStatuaCollider;
    public GameObject BassoStatuaCollider;
    public GameObject DestraGammurCollider;
    public GameObject SinistraGammurCollider;


    [Header("General Reference")]
    public int health;
    public GameObject shadow;

    //public int healthFireball = 1;
    //public int healthTornado = 1;
    //public int healthSnowball = 1;
    //public int healthYellow = 1;
    //public int healthLaser = 1;
    //public int healthAxe = 1;
    //public int healthLance = 1;
    //public int healthScream = 1;
    //public int healthFallEgg = 1;
    //public int healthExplosiveEgg = 1;
    //public int healthChargeTornado = 1;
    //public int healthCannon = 1;
    //public int healthTornadoBergrisi = 1;

    public bool isBoss;
    public int currentHealth;
    public HealthBar healthBar;

    float sfx;
    
    
    
    #region Static Variables
    public static int rangeGammur;
    //public static int rangeBergrisi;
    
    public static bool GammurDeath = false;

    public static bool WallWow2 = false;
    public static bool WallWow3 = false;
    public static bool WallValravn2 = false;
    public static bool WallValravn3 = false;

    public bool ColpitoDalVento = false;
    public bool ColpitoDalLaser = false;

    public bool Move = true;

    #endregion
    #endregion


    public static int WowFound = 0;
    public static int ValravnFound = 0;
    public static int OdinEyeFound = 0;
    public static int GreenFound = 0;
    public static int YellowFound = 0;
    public static int RedFound = 0;
    public static int BlueFound = 0;
    public static int GullinburstiFound = 0;
    public static int DraugrFound = 0;
    public static int GammurFound = 0;
    public static int LokiFound = 0;


    public static int CountEnemyWin = 0;
    public int TempCountEnemyWin = 0;

    public GameObject ExplosionEggCrackerPlayer;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "WallW" || other.gameObject.name == "WallS" || other.gameObject.name == "WallD" || other.gameObject.name == "WallA")
        {
            Move = false;
        }

        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "ShotPlayer" || other.gameObject.tag == "Spike" || other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
        {
            if(other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
            {
                GameObject GoExplosion = Instantiate(ExplosionEggCrackerPlayer, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), transform.rotation);
                Destroy(GoExplosion, 1);
                Destroy(other.gameObject);
            }
            health--;           //Diminuisce la vita del nemico di 1, serve un if se si vuole che i diversi attacchi facciano più o meno danno
            #region Hammer
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion

            #region Fireball Will o' Wisp
            if(other.gameObject.name == "FireballPlayerContainer(Clone)")
            {
                health = health - 1;
            }
            #endregion
            
            #region Snowball Blue Deer
            //Sono tanti piccoli pezzettini
            #endregion
            #region Spine Green Deer
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Fall Fireball Yellow Deer
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Laser Eye
            //Sarà un raycast
            #endregion
            #region Axe Draugr
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Lance DarkElf
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion

            #region Scream Gammur
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Fall Egg Gammur
            //if(other.gameObject.tag == "EggPlayer")
            //{
            //    health--;
            //}
            #endregion
            #region Explosive Egg Gammur
            //if(other.gameObject.tag == "EggcrackerPlayer")
            //{
            //    health--;
            //}
            #endregion

            #region Charge Bergrisi
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Cannon Bergrisi
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion
            #region Tornado Bergrisi
            //if(other.gameObject.name == "")
            //{
            //    health--;
            //}
            #endregion

            StartCoroutine(EnemyHit());

            if(this.gameObject.tag == "Boss")
            {
                Debug.Log("Sto togliendo vita al boss");
                isBoss = true;
                currentHealth--;
                healthBar.SetHealth(currentHealth);
            }
        }
    }
    
    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio delle rne dei mostri come sfx
    }
    private void Start()
    {
        healthBar.gameObject.SetActive(false);
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }
    private void Update()
    {
        TempCountEnemyWin = CountEnemyWin;
        Debug.Log("Count enemy win " + CountEnemyWin);
        #region Tornado Valravn
        if (ColpitoDalVento == true)
        {
            health--;
            ColpitoDalVento = false;
            StartCoroutine(EnemyHit());
            if (gameObject.tag == "Boss")
            {
                isBoss = true;
                currentHealth--;
                healthBar.SetHealth(currentHealth);
            }
        }
        #endregion
        #region Laser Eye
        if (ColpitoDalLaser == true)
        {
            health--;
            ColpitoDalLaser = false;
            Debug.Log("Entra e togli vita all'occhio dai");
            StartCoroutine(EnemyHit());
            if (gameObject.tag == "Boss")
            {
                isBoss = true;
                currentHealth--;
                healthBar.SetHealth(currentHealth);
            }
        }
        #endregion

        if (health <= 0)
        {
            PlayerManager.EnemyTriggerW = 1;
            PlayerManager.EnemyTriggerS = 1;
            PlayerManager.EnemyTriggerD = 1;
            PlayerManager.EnemyTriggerA = 1;
            Destroy(gameObject);

            #region Uccisione del mostro corrispondente

            #region WillOWisp
            if (this.gameObject.name == "WillOfWisp1" || this.gameObject.name == "WillOfWisp2" || this.gameObject.name == "WillOfWisp3" || this.gameObject.name == "WillOfWisp4" || this.gameObject.name == "WillOfWisp5")
            {
                if(this.gameObject.name == "WillOfWisp1")
                {
                    SpikeTrap.isRune = true;
                }
                if (this.gameObject.name == "WillOfWisp2")
                {
                    WallWow2 = true;
                }
                if (this.gameObject.name == "WillOfWisp3")
                {
                    WallWow3 = true;
                }
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                FindObjectOfType<AudioManager>().Play("BaseRuneDrop", sfx);
                rune.GetComponent<RuneWow>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                WowFound = 1;
                for (int i = 0; i < 1; i++)
                {
                    CountEnemyWin++;
                }
            }
            #endregion
            #region Valvran
            if (this.gameObject.name == "NavMeshValvran1" || this.gameObject.name == "Valvran2" || this.gameObject.name == "Valvran3" || this.gameObject.name == "Valvran4")
            {
                if (this.gameObject.name == "Valvran2")
                {
                    WallValravn2 = true;
                }
                if (this.gameObject.name == "Valvran3")
                {
                    WallValravn3 = true;
                }
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                FindObjectOfType<AudioManager>().Play("BaseRuneDrop", sfx);
                rune.GetComponent<RuneValravn>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                ValravnFound = 1;
                for (int i = 0; i < 1; i++)
                {
                    CountEnemyWin++;
                }
            }
            #endregion
            #region Odin's Eye
            if (this.gameObject.name == "Eye1" || this.gameObject.name == "Eye2"/* || this.gameObject.name == "Eye3" || this.gameObject.name == "Eye4"*/)
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneEye>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                OdinEyeFound = 1;
                for (int i = 0; i < 1; i++)
                {
                    CountEnemyWin++;
                }
            }
            #endregion
            #region Yggdrasil Deer
            if (this.gameObject.name == "DeerBlue1")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneBlue>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                BlueFound = 1;
            }
            if (this.gameObject.name == "DeerGreen1" || this.gameObject.name == "DeerGreen2")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneGreen>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                GreenFound = 1;
                for (int i = 0; i < 1; i++)
                {
                    CountEnemyWin++;
                }
            }
            if (this.gameObject.name == "DeerYellow1")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneYellow>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                YellowFound = 1;
            }
            if (this.gameObject.name == "DeerRed1")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneOrange>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                RedFound = 1;
            }
            #endregion
            #region Gullinbursti
            //if (this.gameObject.name == "Gullinbursti1" || this.gameObject.name == "Gullinbursti2" || this.gameObject.name == "Gullinbursti3")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneGullinbursti>().enabled = false;
            //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
            //shadow1.transform.parent = rune.transform;
            //}
            #endregion
            #region Darkelf
            if (this.gameObject.name == "DarkElf1" || this.gameObject.name == "DarkElf2"/* || this.gameObject.name == "DarkElf3"*/)
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneDarkElf>().enabled = false;
                //GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
                //shadow1.transform.parent = rune.transform;
                //DarkElfFound = 1;
                for (int i = 0; i < 1; i++)
                {
                    CountEnemyWin++;
                }
            }
            #endregion
            #region Draugr
            //if (this.gameObject.name == "Draugr1" || this.gameObject.name == "Draugr2" || this.gameObject.name == "Draugr3"|| this.gameObject.name == "Draugr4" || this.gameObject.name == "Draugr5")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneDraugr>().enabled = false;
            //    GameObject shadow1 = Instantiate(shadow, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
            //    shadow1.transform.parent = rune.transform;
            //}
            #endregion

            #endregion

        }
        if (health <= 0 && gameObject.tag == "Boss" && isBoss == true)
        {

            #region Collider della stanza di gammur
            healthBar.gameObject.SetActive(false);
            PrecedentCollider.SetActive(true);
            
            AltoStatuaCollider.SetActive(false);
            BassoStatuaCollider.SetActive(false);
            DestraGammurCollider.SetActive(false);
            SinistraGammurCollider.SetActive(false);

            DoorCollider.SetActive(false);
            #endregion

            #region Gammur
            if (this.gameObject.name == "GammurBoss")
            {
                GammurFound = 1;
                Destroy(BossContainer);
                Hole.SetActive(true);

                GammurDeath = true;
                rangeGammur = Random.Range(1,4);
                switch (rangeGammur)
                {
                    case 1:
                        {
                            Quaternion rot = new Quaternion(0, 90, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
;                           GameObject rune = Instantiate(RuneBossGammur1, pot, rot);
                            FindObjectOfType<AudioManager>().Play("BossRuneDrop", sfx);
                            rune.GetComponent<RuneGammurOne>().enabled = false;
                            rune.GetComponent<RuneGammurTwo>().enabled = false;
                            rune.GetComponent<RuneGammurThree>().enabled = false;
                            
                            break;
                        }
                    case 2:
                        {
                            Quaternion rot = new Quaternion(0, 0, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
                            GameObject rune = Instantiate(RuneBossGammur2, pot, rot);
                            FindObjectOfType<AudioManager>().Play("BossRuneDrop", sfx);
                            rune.GetComponent<RuneGammurOne>().enabled = false;
                            rune.GetComponent<RuneGammurTwo>().enabled = false;
                            rune.GetComponent<RuneGammurThree>().enabled = false;
                            //Destroy(BossContainer);
                            break;
                        }
                    case 3:
                        {
                            Quaternion rot = new Quaternion(0, 0, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
                            GameObject rune = Instantiate(RuneBossGammur3, pot, rot);
                            FindObjectOfType<AudioManager>().Play("BossRuneDrop", sfx);
                            rune.GetComponent<RuneGammurOne>().enabled = false;
                            rune.GetComponent<RuneGammurTwo>().enabled = false;
                            rune.GetComponent<RuneGammurThree>().enabled = false;
                            //Destroy(BossContainer);
                            break;
                        }
                    default:
                        break;
                }

            }
            #endregion
            #region Bergrisi
            //if (this.gameObject.name == "Bergrisi")
            //{
            //    int range = Random.Range(1, 4);
            //    switch (range)
            //    {
            //        case 1:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        case 2:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        case 3:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        default:
            //            break;
            //    }
            //
            //}
            #endregion
        }
    }

    IEnumerator EnemyHit()      //IEnumerator per quando il nemico viene colpito
    {
        GraphicsEnemy.material = MaterialChange;
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(0.5f);
        GraphicsEnemy.material = MaterialStandardEnemy;
        GraphicsBase.material = MaterialStandardBase;
    }
}