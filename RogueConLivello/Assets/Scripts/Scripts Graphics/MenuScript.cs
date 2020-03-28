using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MenuScript : MonoBehaviour
{
    #region Variables
    // Create a public Slider for Brightnees
    public Slider brithgnessSlider;
    // Create a public Toggle for Fullscreen
    public Toggle fullscreenToggle;
    // Create an array for Resolutions
    Resolution[] resolutions;
    // Create a public Dropdown for Resolutions
    public Dropdown resolutionDropdown;
    #endregion
    #region Start
    private void Start()
    {
        // Set default option for Resolutions
        Resolution();
        SetFullscren(true);
    }

    // Create a function for setting resolution
    // Drag this through inspector : select Dropdown in Hierarchy, drag canvas "On Value Change"
    // From "On Vale Change" select the Dropdown e choose Menu Script, (Dynamic Int) SetResolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion
    #region Brightness
    public void SetBrightness(float brightness)
    {
        brightness = Screen.brightness;
        //brightness = 
    }
    #endregion
    #region Fullscren
    // Select FullScreen toggle, drag the canvas "On Value change", Setting Menu, (Dynamic Bool) SetFullscreen    
    public void SetFullscren(bool isFullscreen)
    {
        // Create a bool for fullscreen true /false
        Screen.fullScreen = isFullscreen;               
    }
    #endregion
    #region Resolution Setting
    public void Resolution()
    {
        // Set our resolution to Screen.resolution
        resolutions = Screen.resolutions;
        // Clear the option in the resolution Dropdown
        resolutionDropdown.ClearOptions();
        

        // Create a list of options
        List<string> options = new List<string>();        
        // Set the currentResolutionIndex to 0
        int currentResolutionIndex = 0;

        // Create a for loop wich run through the resolutions
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Create a string for visualize resolution (width x height)
            string option = resolutions[i].width + "x" + resolutions[i].height;
            // Add option to the list
            if (options.Contains(option) == false)
                options.Add(option);

            // Set index of Array
            int index = option.IndexOf(option);

            // Linq Solution for duplicates => Distinct()
            //resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
            //resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

            if (resolutions[index].Equals(Screen.currentResolution))
            {
                currentResolutionIndex = index;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    #endregion
    #region Quality Setting
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    #endregion
    #region Default Setting
    // Create a function for default settings
    public void Default()
    {
        brithgnessSlider.value = 0.5f;
        SetFullscren(true);
        fullscreenToggle.isOn = true;        
        Resolution();
    }
    #endregion
}
