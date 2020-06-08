using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numItemToSpawn = 10;

    public float itemXSpread = 10f;
    public float itemYSpread = 0f;
    public float itemZSpread = 10f;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject clone = Instantiate(itemToSpread, new Vector3((int)randPosition.x, randPosition.y, (int)randPosition.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(ProvaLoki.isColumn == true)
        {
            for (int i = 0; i < numItemToSpawn; i++)
            {
                SpreadItem();
            }
            ProvaLoki.isColumn = false;
        }
    }
}
