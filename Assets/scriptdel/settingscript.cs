using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class settingscript : MonoBehaviour
{
    public TMP_Dropdown Dropdown_Graphics;
    public Slider musicVol, sfxVol;
    public AudioMixer SoundMixer;
    Resolution[] resolutions;
    public TMP_Dropdown ResolutionDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int CurrentIndex = 0;
        for (int i = 0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentIndex = i; break;
            }
        } 

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = CurrentIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(Dropdown_Graphics.value);
    }
 
    public void ChangeMusVolume()
    {
        SoundMixer.SetFloat("MusicExp", musicVol.value);

    }

    public void ChangeSFXVolume()
    {
        SoundMixer.SetFloat("SFXExp", sfxVol.value);

    }
    
    public void SetFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;

    }
}
