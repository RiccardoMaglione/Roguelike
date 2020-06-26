using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    Vector3 InitialPosition;
    Vector3 TwoPosition;
    Vector3 ThreePosition;
    Vector3 FourPosition;
    Vector3 FivePosition;
    Vector3 SixPosition;
    static public bool open = false;
    public bool isMove = false;
    public int speed = 1;

    private void Start()
    {
        InitialPosition = new Vector3(-34, transform.position.y, transform.position.z);

        TwoPosition = new Vector3(-34, transform.position.y, transform.position.z);
        ThreePosition = new Vector3(-34, transform.position.y, 1);
        FourPosition = new Vector3(-37, transform.position.y, 1);
        FivePosition = new Vector3(-37, transform.position.y, -2);
        SixPosition = new Vector3(-34, transform.position.y, -2);
    }

    private void Update()
    {
        TutorialMove();
    }

    public void TutorialMove()
    {
        if (open)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, InitialPosition, Time.deltaTime * speed);
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(5);
        open = false;
        this.transform.position = Vector3.Lerp(this.transform.position, TwoPosition, Time.deltaTime * speed);
        while (true)
        {
            yield return new WaitForSeconds(5);
            this.transform.position = Vector3.Lerp(this.transform.position, ThreePosition, Time.deltaTime * speed);
            yield return new WaitForSeconds(5);
            this.transform.position = Vector3.Lerp(this.transform.position, FourPosition, Time.deltaTime * speed);
            yield return new WaitForSeconds(5);
            this.transform.position = Vector3.Lerp(this.transform.position, FivePosition, Time.deltaTime * speed);
            yield return new WaitForSeconds(5);
            this.transform.position = Vector3.Lerp(this.transform.position, SixPosition, Time.deltaTime * speed);
        }
    }
}