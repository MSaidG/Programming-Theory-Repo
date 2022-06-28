using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]private AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Slider volume;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0;i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(1920, 1080, true);
        qualityDropdown.value = QualitySettings.GetQualityLevel();

    }


    private void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetGraphicQuality()
    {
        int qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution()
    {
        if(resolutionDropdown.value == 0)  Screen.SetResolution(640, 480, true);
        if (resolutionDropdown.value == 1) Screen.SetResolution(720, 480, true);
        if (resolutionDropdown.value == 2) Screen.SetResolution(720, 576, true);
        if (resolutionDropdown.value == 3) Screen.SetResolution(800, 600, true);
        if (resolutionDropdown.value == 4) Screen.SetResolution(1024, 768, true);
        if (resolutionDropdown.value == 5) Screen.SetResolution(1152, 864, true);
        if (resolutionDropdown.value == 6) Screen.SetResolution(1176, 664, true);
        if (resolutionDropdown.value == 7) Screen.SetResolution(1280, 720, true);
        if (resolutionDropdown.value == 8) Screen.SetResolution(1280, 768, true);
        if (resolutionDropdown.value == 9) Screen.SetResolution(1280, 800, true);
        if (resolutionDropdown.value == 10) Screen.SetResolution(1280, 1024, true);
        if (resolutionDropdown.value == 11) Screen.SetResolution(1360, 768, true);
        if (resolutionDropdown.value == 12) Screen.SetResolution(1366, 768, true);
        if (resolutionDropdown.value == 13) Screen.SetResolution(1440, 900, true);
        if (resolutionDropdown.value == 14) Screen.SetResolution(1600, 900, true);
        if (resolutionDropdown.value == 15) Screen.SetResolution(1600, 1024, true);
        if (resolutionDropdown.value == 16) Screen.SetResolution(1680, 1050, true);
        if (resolutionDropdown.value == 17) Screen.SetResolution(1920, 1080, true);
        if (resolutionDropdown.value == 18) Screen.SetResolution(3840, 2160, true);
    }

}
