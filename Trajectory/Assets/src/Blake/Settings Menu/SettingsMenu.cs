using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SettingsMenu : MonoBehaviour
{
    public static float sens = 100f;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start ()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionI = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i] + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionI = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionI;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Used with the slider to change the Player's Mouse Sensitivity
    public void SetSensitivity (float sens)
    {
        Camera.mouseSensitivity = sens;
    }

    //Used with Drop down to set Quality.
    /*
     * int index:
     * 0 = Very Low
     * 1 = Low (Mobile Default setting)
     * 2 = Medium
     * 3 = High (Desktop Default setting)
     * 4 = Very High
     * 5 = Ultra
    */
    public void SetQuality (int qual)
    {
        //Debug.Log(qual);
        QualitySettings.SetQualityLevel(qual);
    }
}
