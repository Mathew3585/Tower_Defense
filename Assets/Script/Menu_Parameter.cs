using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Menu_Parameter : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public TMP_Dropdown resolutionsDropdown;

    void Start()
    {
        resolutions =  Screen.resolutions;
        resolutionsDropdown.ClearOptions();


        List<string> option = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            option.Add(options);
            if( resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(option);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }


    public void SetResolution ( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {

        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }


    public void SetQuality (int qualitieIndex)
    {
        Debug.Log(qualitieIndex);
        QualitySettings.SetQualityLevel(qualitieIndex);
    }

    public void SetFullScrenn (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
