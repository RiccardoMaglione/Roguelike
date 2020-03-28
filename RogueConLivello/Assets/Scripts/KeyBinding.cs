using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump;

    private GameObject currentKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

    // Start is called before the first frame update
    void Start()
    {
        //button controllo contiene text con il controllo relativo, quindi setto il public con il text
        keys.Add("Up",(KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up","W"))); //se cambio il controllo da qua, me lo cambia anche in gioco
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        keys.Add("Up", KeyCode.W); 
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Jump", KeyCode.Space);

        up.text = keys["Up"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        jump.text = keys["Jump"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Up"]))
        {
            //do a move action
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(keys["Down"]))
        {
            //do a move action
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            //do a move action
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            //do a move action
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["Jump"]))
        {
            //do a move action
            Debug.Log("Jump");
        }
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }
    
    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
        //poi nei button metto onclik, ci metto l'oggetto con lo script, metto lo changekey e mi compare
        //una schermata e ci metto se stesso bottone
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            print("Salvato le chiave");
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}