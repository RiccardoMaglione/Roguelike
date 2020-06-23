using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternGammur : MonoBehaviour
{
    #region Variables
    [Header("Reference for Gammur")]
    public GameObject ScreamPart;
    public GameObject Gammur;
    public GameObject Egg;
    public GameObject ChickenMinion;
    public Transform GammurTransformParent;
    public Slider HealthBarSlider;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    [Header("General Reference")]
    public GameObject Player;
    public GameObject shadowScream;
    public GameObject shadowEgg;
    public GameObject PortaBoss;
    public GameObject DoorCollider;
    public GameObject PrecedentCollider;
    public float CooldownFlash = 0.5f;

    float sfx;
    #endregion
    public GameObject AnimationDust;
    Vector3 newPos;
    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");
    }
    private void Update()
    {
        if (GammurTrigger.GP == true)
        {
            PortaBoss.SetActive(true);
            PrecedentCollider.SetActive(false);
            DoorCollider.SetActive(true);
            StartCoroutine(GammurAttack());
            HealthBarSlider.gameObject.SetActive(true);
            GammurTrigger.GP = false;
        }
    }

    #region Pattern
    void EggBomb()
    {
        float radius = 2f;
        for (int i = 0; i < 3; i++)
        {
            float angle = i * Mathf.PI * 2f / 3;
            newPos = new Vector3(Player.transform.position.x + Mathf.Cos(angle) * radius, 10, Player.transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(Egg, newPos, Quaternion.identity);
            GameObject shadow1 = Instantiate(shadowEgg, new Vector3(newPos.x, 0.1f, newPos.z), Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("EggCrackerSound", sfx);
            go.transform.SetParent(GammurTransformParent);
            shadow1.transform.SetParent(GammurTransformParent);
            shadow1.transform.parent = go.transform;
            Rigidbody rg = go.AddComponent<Rigidbody>();
            GameObject Dust = Instantiate(AnimationDust, new Vector3(newPos.x, 0.1f, newPos.z), transform.rotation);
            Destroy(Dust, 3);
        }
    }
    void SpawnMinion()
    {
        float radius = 3f;
        for (int i = 0; i < 6; i++)
        {
            float angle = i * Mathf.PI * 2f / 6;
            Vector3 newPos = new Vector3(GammurTransformParent.transform.position.x + Mathf.Cos(angle) * radius, GammurTransformParent.transform.position.y, GammurTransformParent.transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(ChickenMinion, newPos, Quaternion.identity);
            //go.transform.SetParent(GammurTransformParent);
            go.AddComponent<MinionLookAt>();
        }
    }
    #endregion

    #region IEnumerator Attack and Flash
    public IEnumerator GammurAttack()
    {
        while (true)
        {
            StartCoroutine(Flash());
            yield return new WaitForSeconds((float)3f);
            StartCoroutine(Flash());
            StartCoroutine(Scream());
            yield return new WaitForSeconds((float)10f);
            StartCoroutine(Flash());
            SpawnMinion();
            yield return new WaitForSeconds((float)10f);
            StartCoroutine(Flash());
            EggBomb();
            yield return new WaitForSeconds((float)3f);
        }
    }
    public IEnumerator Scream()
    {
        FindObjectOfType<AudioManager>().Play("GammurSound", sfx);
        for (int i = 0; i < 3; i++)
        {
            GameObject Scream1 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 4, transform.position.y, Gammur.transform.position.z + 1), Quaternion.identity); //1
            GameObject shadow1 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 4, 0.1f, GammurTransformParent.transform.localPosition.z + 1)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow1.tag = "Scream";
            shadow1.transform.parent = Scream1.transform;
            GameObject Scream2 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 4, transform.position.y, Gammur.transform.position.z - 0), Quaternion.identity); //2
            GameObject shadow2 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 4, 0.1f, GammurTransformParent.transform.localPosition.z - 0)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow2.tag = "Scream";
            shadow2.transform.parent = Scream2.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject Scream3 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity); //3
            GameObject shadow3 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 3, 0.1f, GammurTransformParent.transform.localPosition.z + 2)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow3.tag = "Scream";
            shadow3.transform.parent = Scream3.transform;
            GameObject Scream4 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z - 1), Quaternion.identity); //4
            GameObject shadow4 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 3, 0.1f, GammurTransformParent.transform.localPosition.z - 1)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow4.tag = "Scream";
            shadow4.transform.parent = Scream4.transform;
            GameObject Scream5 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity); //5
            GameObject shadow5 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 3, 0.1f, GammurTransformParent.transform.localPosition.z + 3)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow5.tag = "Scream";
            shadow5.transform.parent = Scream5.transform;
            GameObject Scream6 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z - 2), Quaternion.identity); //6
            GameObject shadow6 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 3, 0.1f, GammurTransformParent.transform.localPosition.z - 2)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow6.tag = "Scream";
            shadow6.transform.parent = Scream6.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject Scream7 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 2, transform.position.y, Gammur.transform.position.z + 1), Quaternion.identity); //7
            GameObject shadow7 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 2, 0.1f, GammurTransformParent.transform.localPosition.z + 1)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow7.tag = "Scream";
            shadow7.transform.parent = Scream7.transform;
            GameObject Scream8 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 2, transform.position.y, Gammur.transform.position.z - 0), Quaternion.identity); //8
            GameObject shadow8 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 2, 0.1f, GammurTransformParent.transform.localPosition.z - 0)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow8.tag = "Scream";
            shadow8.transform.parent = Scream8.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject Scream9 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z + 4), Quaternion.identity); //9
            GameObject shadow9 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 1, 0.1f, GammurTransformParent.transform.localPosition.z + 4)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow9.tag = "Scream";
            shadow9.transform.parent = Scream9.transform;
            GameObject Scream10 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z - 3), Quaternion.identity); //10
            GameObject shadow10 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 1, 0.1f, GammurTransformParent.transform.localPosition.z - 3)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow10.tag = "Scream";
            shadow10.transform.parent = Scream10.transform;
            yield return new WaitForSeconds((float)0.2f);
            GameObject Scream11 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z + 5), Quaternion.identity); //11
            GameObject shadow11 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 1, 0.1f, GammurTransformParent.transform.localPosition.z + 5)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow11.tag = "Scream";
            shadow11.transform.parent = Scream11.transform;
            GameObject Scream12 = Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z - 4), Quaternion.identity); //12
            GameObject shadow12 = Instantiate(shadowScream, new Vector3(GammurTransformParent.transform.localPosition.x - 1, 0.1f, GammurTransformParent.transform.localPosition.z - 4)/* + (transform.forward * 0.6f)*/, Quaternion.identity);
            shadow12.tag = "Scream";
            shadow12.transform.parent = Scream12.transform;
            yield return new WaitForSeconds((float)2f);
        }
    }
    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion
}