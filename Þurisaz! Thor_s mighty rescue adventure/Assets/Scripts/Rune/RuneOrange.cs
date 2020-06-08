using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneOrange : MonoBehaviour
{
    #region Variables
    [Header("Reference for Attack")]
    public GameObject Fireball;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public int HeightAttack = 5;
    public float CooldownAttack = 3f;
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
            StartCoroutine(FireballAttack());
        }
    }

    #region Pattern
    void SpawnFireball()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = 2; i < 6; i++)
        {
            GameObject go = Instantiate(Fireball, new Vector3(PlayerContainer.transform.localPosition.x, PlayerContainer.transform.localPosition.y + HeightAttack, PlayerContainer.transform.localPosition.z) + PlayerContainer.transform.right * i, transform.rotation);
        }
    }
    #endregion

    #region IEnumerator Attack
    public IEnumerator FireballAttack()
    {
        SpawnFireball();
        yield return new WaitForSeconds(CooldownAttack);
        isFinishAttack = true;
    }
    #endregion
}
