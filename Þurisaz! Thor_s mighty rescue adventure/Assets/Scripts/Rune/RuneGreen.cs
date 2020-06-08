using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneGreen : MonoBehaviour
{

    #region Variables
    [Header("Reference for Attack")]
    public GameObject Spine;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    bool isFinishAttack = true;

    float sfx;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && isFinishAttack == true)
        {
            isFinishAttack = false;
            StartCoroutine(SpineAttack());
        }
    }


    #region Pattern
    void SpawnSpike()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                GameObject go = Instantiate(Spine, new Vector3(transform.position.x + i, /*transform.position.y*/0, transform.position.z + j), Quaternion.identity);
                go.transform.parent = PlayerContainer.transform;
                if (go.transform.position.x == PlayerContainer.transform.position.x && go.transform.position.z == PlayerContainer.transform.position.z)
                    Destroy(go);
                Destroy(go, 3f);
            }
        }

    }
    #endregion

    #region IEnumerator Attack
    public IEnumerator SpineAttack()
    {
        SpawnSpike();
        yield return new WaitForSeconds(CooldownAttack);
        isFinishAttack = true;
    }
    #endregion

}
