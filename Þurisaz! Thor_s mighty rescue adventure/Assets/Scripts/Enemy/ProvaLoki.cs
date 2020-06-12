using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaLoki : MonoBehaviour
{
    public GameObject shotReference;
    public GameObject WowContainer;


    #region Walls Variable
    public GameObject wall1, wall1A, wall2, wall2A, wall3, wall3A;
    int rand;
    bool start = false;
    Vector3 go;
    Vector3 go2;
    float timer = 0;
    bool isPause = false;
    bool isFinish = false;
    int num = 0;
    float actualSpeed;


    [Header("DESIGN")]

    [Tooltip("Velocità con cui i muri escono")]
    public float startSpeed;

    [Tooltip("Velocità con cui i muri si chiudono")]
    public float speed;

    [Tooltip("Tempo di pausa prima che i muri si chiudono")]
    public int pause;

    [Tooltip("Numero di volte che le pareti si scontrano")]
    public int repetitions;
    #endregion

    public bool OnWall = false;
    public int NumRep8 = 5;
    public static bool isActivate = false;
    public static bool Is8 = false;
    public static bool isColumn = false;
    public static bool isDestroyColumnIce = false;
    public static bool isDestroyColumnFire = false;
    public GameObject Walls;
    public int u = 0;
    public int NumSky = 5;
    public GameObject FireSkyBall;
    bool isSky = false;

    public int NumClone = 3;
    public GameObject Loki;
    bool isClone = false;
    public IEnumerator WowAttack()
    {
        //while (true)
        //{
            for (int i = 0; i < NumRep8; i++)
            {
                yield return new WaitForSeconds((float)1f);
                AttackShotAround();
            }
            OnWall = true;
        //}
    }

    private void Start()
    {
        //StartCoroutine(WowAttack());
    }

    void AttackShotAround()
    {
        GameObject newShot1 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, 0, 0));
        GameObject newShot2 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, 45, 0));
        GameObject newShot3 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, 90, 0));
        GameObject newShot4 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, 135, 0));
        GameObject newShot5 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, 180, 0));
        GameObject newShot6 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, -135, 0));
        GameObject newShot7 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, -90, 0));
        GameObject newShot8 = Instantiate(shotReference, WowContainer.transform.position, Quaternion.Euler(0, -45, 0));
        
    }

    public void FireSky()
    {
        for (int n = 0; n < NumSky; n++)
        {
            Instantiate(FireSkyBall, new Vector3(Random.Range(-5, 5), 7, Random.Range(-5, 5)), Quaternion.identity);
        }
        isSky = true;
    }

    public void Clone()
    {
        for (int n = 0; n < NumClone; n++)
        {
            GameObject go = Instantiate(Loki, new Vector3(Random.Range(-5, 5), 0, Random.Range(-7, 7)), Quaternion.identity);
            Destroy(go, 5);
        }
        isClone = true;
    }


    private void Update()
    {
        if(isActivate == true)
        {
            if (Is8 == true)
            {
                Is8 = false;
                isDestroyColumnFire = false;
                isDestroyColumnFire = false;
                #region Attacco a 8
                StartCoroutine(WowAttack());
                #endregion
            }
            if (OnWall == true)
            {
                Walls.SetActive(true);
                #region Attacco Muri
                if (start == false && num < repetitions)
        {
            isPause = false;
            isFinish = false;

            go.x = 0;
            rand = Random.Range(1, 4);
        }


                if (rand == 1)
        {
            if (go.x == 0)
            {
                go = wall1.transform.position + transform.forward * 1f;
                go2 = wall1A.transform.position - transform.forward * 1f;
                actualSpeed = startSpeed;
            }

            start = true;

            wall1.transform.position = Vector3.MoveTowards(wall1.transform.position, go, actualSpeed * Time.deltaTime);
            wall1A.transform.position = Vector3.MoveTowards(wall1A.transform.position, go2, actualSpeed * Time.deltaTime);

            if (wall1.transform.position == go && isPause == false)
            {
                timer = timer + Time.deltaTime;
            }

            if (timer >= pause)
            {
                go = wall1.transform.position + transform.forward * 6.5f;
                go2 = wall1A.transform.position - transform.forward * 6.5f;
                actualSpeed = speed;
                isPause = true;
                timer = 0;
            }

            if (wall1.transform.position == go && isPause == true && isFinish == false)
            {
                go = wall1.transform.position - transform.forward * 7.5f;
                go2 = wall1A.transform.position + transform.forward * 7.5f;
                isFinish = true;
            }

            if (wall1.transform.position == go && isPause == true && isFinish == true)
            {
                start = false;
                num++;
            }
        }

                if (rand == 2)
        {
            if (go.x == 0)
            {
                go = wall2.transform.position + transform.forward * 1f;
                go2 = wall2A.transform.position - transform.forward * 1f;
                actualSpeed = startSpeed;
            }

            start = true;

            wall2.transform.position = Vector3.MoveTowards(wall2.transform.position, go, actualSpeed * Time.deltaTime);
            wall2A.transform.position = Vector3.MoveTowards(wall2A.transform.position, go2, actualSpeed * Time.deltaTime);

            if (wall2.transform.position == go && isPause == false)
            {
                timer = timer + Time.deltaTime;
            }

            if (timer >= pause)
            {
                go = wall2.transform.position + transform.forward * 6.5f;
                go2 = wall2A.transform.position - transform.forward * 6.5f;
                actualSpeed = speed;
                isPause = true;
                timer = 0;
            }

            if (wall2.transform.position == go && isPause == true && isFinish == false)
            {
                go = wall2.transform.position - transform.forward * 7.5f;
                go2 = wall2A.transform.position + transform.forward * 7.5f;
                isFinish = true;
            }

            if (wall2.transform.position == go && isPause == true && isFinish == true)
            {
                start = false;
                num++;
            }
        }

                if (rand == 3)
        {
            if (go.x == 0)
            {
                go = wall3.transform.position + transform.forward * 1f;
                go2 = wall3A.transform.position - transform.forward * 1f;
                actualSpeed = startSpeed;
            }

            start = true;

            wall3.transform.position = Vector3.MoveTowards(wall3.transform.position, go, actualSpeed * Time.deltaTime);
            wall3A.transform.position = Vector3.MoveTowards(wall3A.transform.position, go2, actualSpeed * Time.deltaTime);

            if (wall3.transform.position == go && isPause == false)
            {
                timer = timer + Time.deltaTime;
            }

            if (timer >= pause)
            {
                go = wall3.transform.position + transform.forward * 6.5f;
                go2 = wall3A.transform.position - transform.forward * 6.5f;
                actualSpeed = speed;
                isPause = true;
                timer = 0;
            }

            if (wall3.transform.position == go && isPause == true && isFinish == false)
            {
                go = wall3.transform.position - transform.forward * 7.5f;
                go2 = wall3A.transform.position + transform.forward * 7.5f;
                isFinish = true;
            }

            if (wall3.transform.position == go && isPause == true && isFinish == true)
            {
                start = false;
                num++;
            }
        }
                #endregion
                if(num >= repetitions)
                {
                    OnWall = false;
                    isColumn = true;
                    num = 0;
                    Walls.SetActive(false);
                }
            }
            if(isDestroyColumnFire == true && isDestroyColumnIce == true)
            {
                FireSky();
            }
            if(isSky == true)
            {
                isClone = true;
                isSky = false;
                Clone();
            }
            if (isClone == true)
            {
                Is8 = true;
                isClone = false;
            }
        }
    }
}