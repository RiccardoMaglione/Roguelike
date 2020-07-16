using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAlignerNoOverlap : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public float raycastDistance = 100f;
    public float overlapBoxSize = 1f;
    public LayerMask spawnedObjectLayer;
    Vector3 offSet = new Vector3(0f, 1.5f, 0f);
    RaycastHit hit;
    Vector3 overlapTestBoxScale;
    // Start is called before the first frame update
    void Start()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        //RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            Vector3 overlapTestBoxScale = new Vector3(overlapBoxSize, overlapBoxSize, overlapBoxSize);
            Collider[] colliderInsideOverlapBox = new Collider[1];
            int numberOfColliderFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, colliderInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            print("number of collider found " + numberOfColliderFound);

            if (numberOfColliderFound == 0)
            {
                print("spawned column");
                Pick(hit.point);
            }
            else
            {
                print("name of collider 0 found " + colliderInsideOverlapBox[0].name);
            }
        }
    }

    void Pick(Vector3 positionToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn + offSet, itemsToPickFrom[randomIndex].transform.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(hit.point, overlapBoxSize);
    }
}
