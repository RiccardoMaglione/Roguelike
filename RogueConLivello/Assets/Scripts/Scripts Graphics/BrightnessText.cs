using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessText : MonoBehaviour
{
    #region Variable
    // Variable text
    Text brightnessText;
    #endregion
    #region Start
    private void Start()
    {        
        brightnessText = GetComponent<Text>();
    }
    #endregion
    #region Setting Text
    public void TextUpdate(float value)
    {
        //Set text in canvas with % number near slider
        brightnessText.text = Mathf.RoundToInt(value * 100) + "%";
    }
    #endregion
}
