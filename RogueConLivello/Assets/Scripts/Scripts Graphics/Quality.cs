using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 200, 1000), "Graphics Resolution");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Fastest"))
        {
            QualitySettings.currentLevel = QualityLevel.Fastest;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Fast"))
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 100, 80, 20), "Simple"))
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 130, 80, 20), "Good"))
        {
            QualitySettings.currentLevel = QualityLevel.Good;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 160, 80, 20), "Beautiful"))
        {
            QualitySettings.currentLevel = QualityLevel.Beautiful;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 190, 80, 20), "Fantastic"))
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        }
    }
}
