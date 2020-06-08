using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBlue : MonoBehaviour
{
    #region Variables
    [Header("Reference for Attack")]
    public GameObject Snowball;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    bool isFinishAttack = true;

    float sfx;
    #endregion

    private void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && isFinishAttack == true)
        {
            isFinishAttack = false;
            StartCoroutine(SnowballAttack());
        }
        
    }

    #region Pattern
    void SpawnSnowball()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        GameObject go = Instantiate(Snowball, new Vector3(PlayerContainer.transform.position.x, PlayerContainer.transform.position.y, PlayerContainer.transform.position.z), transform.rotation);
        Destroy(go, 10);
    }
    #endregion

    #region IEnumerator Attack
    public IEnumerator SnowballAttack()
    {
        SpawnSnowball();
        yield return new WaitForSeconds(CooldownAttack);
        isFinishAttack = true;
    }
    #endregion
}
