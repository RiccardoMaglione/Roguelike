using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionText : MonoBehaviour
{
    Text resolutionTest;
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        resolutionTest = GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        resolutionTest.text = FindObjectOfType<Dropdown>().options.Count().ToString();
    }
}
