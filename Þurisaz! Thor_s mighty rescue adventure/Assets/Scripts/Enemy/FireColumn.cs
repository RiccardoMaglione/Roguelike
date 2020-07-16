using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColumn : MonoBehaviour
{
    public Transform[] firePoint;

    public GameObject projectile;

    public int numberOfShoot = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        print(StartCoroutine("Shoot"));
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < numberOfShoot; i++)
        {
            foreach (Transform point in firePoint)
            {
                GameObject clone = Instantiate(projectile, point.transform.position, Quaternion.identity);
            }

            foreach (Transform point2 in firePoint)
            {
                GameObject clone2 = Instantiate(projectile, point2.transform.position, Quaternion.Euler(0, 90, 0));
            }

            foreach (Transform point3 in firePoint)
            {
                GameObject clone3 = Instantiate(projectile, point3.transform.position, Quaternion.Euler(0, 180, 0));
            }

            foreach (Transform point4 in firePoint)
            {
                GameObject clone4 = Instantiate(projectile, point4.transform.position, Quaternion.Euler(0, 270, 0));
            }

            yield return new WaitForSeconds(1f);
        }

        if (numberOfShoot >= 10)
        {
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
            ProvaLoki.isDestroyColumnFire = true;
        }        
    }
}
