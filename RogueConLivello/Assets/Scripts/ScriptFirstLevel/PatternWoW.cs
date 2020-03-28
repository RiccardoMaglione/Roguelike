using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternWoW : MonoBehaviour
{
    public GameObject shotReference;

    public IEnumerator WowAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)1f);
            AttackShotAround();
            yield return new WaitForSeconds((float)1f);
            Attack3Angle();
            yield return new WaitForSeconds((float)1f);
            Attack3Shot();
            yield return new WaitForSeconds((float)1f);
        }
    }
    void AttackShotAround()
    {
        GameObject newShot1 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, 0, 0));
        GameObject newShot2 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, 45, 0));
        GameObject newShot3 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, 90, 0));
        GameObject newShot4 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, 135, 0));
        GameObject newShot5 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, 180, 0));
        GameObject newShot6 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, -135, 0));
        GameObject newShot7 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, -90, 0));
        GameObject newShot8 = Instantiate(shotReference, transform.position, Quaternion.Euler(0, -45, 0));
    }

    void Attack3Angle()
    {
        GameObject newShot1 = Instantiate(shotReference, transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
        GameObject newShot2 = Instantiate(shotReference, transform.localPosition + (transform.forward * 0.6f), transform.rotation);
        GameObject newShot3 = Instantiate(shotReference, transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));
    }

    void Attack3Shot()
    {


        GameObject newShot1 = Instantiate(shotReference, transform.position + (transform.forward * 0.6f), transform.rotation);
        GameObject newShot2 = Instantiate(shotReference, transform.position + (transform.forward * 0.6f) + (transform.right * 0.6f), transform.rotation);
        GameObject newShot3 = Instantiate(shotReference, transform.position + (transform.forward * 0.6f) + (transform.right * -0.6f), transform.rotation);

    }

    Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WowAttack());
    }
    private void Update()
    {
        transform.LookAt(target);
    }
}
