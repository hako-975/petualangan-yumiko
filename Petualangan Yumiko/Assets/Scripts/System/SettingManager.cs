using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using Cinemachine;

public class SettingManager : MonoBehaviour
{
    public AudioMixer mixerSFX;
    public AudioMixer mixerMusic;

    CinemachineCoreGetInputTouchAxis touchSensitivity;

    // GameObject
    public Slider sliderSFX;
    public Slider sliderMusic;
    public Slider sliderSensitivity;
    public Slider sliderZoom;

    public TMP_Dropdown dropdownQuality;
    public TMP_Dropdown dropdownLanguage;

    CinemachineFreeLook cinemachineFreeLook;

    private void Start()
    {
        cinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();
        touchSensitivity = FindObjectOfType<CinemachineCoreGetInputTouchAxis>();
    }

    public void SetSFX(float volumeSFX)
    {
        mixerSFX.SetFloat("SFX", volumeSFX);
        PlayerPrefsManager.instance.SetSFX(volumeSFX);
    }
    
    public void SetMusic(float volumeMusic)
    {
        mixerMusic.SetFloat("Music", volumeMusic);
        PlayerPrefsManager.instance.SetMusic(volumeMusic);
    }

    public void SetSensitivity(float sensitivity)
    {
        touchSensitivity.touchSensitivity = sensitivity;
        PlayerPrefsManager.instance.SetSensitivity(sensitivity);
    }
    public void SetZoom(float zoom)
    {
        cinemachineFreeLook.m_CommonLens = true;
        cinemachineFreeLook.m_Lens.FieldOfView = zoom;
        PlayerPrefsManager.instance.SetZoom(zoom);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefsManager.instance.SetQuality(qualityIndex);
    }

    public void SetDefaultSetting()
    {
        PlayerPrefsManager.instance.DeleteKey("SFX");
        
        PlayerPrefsManager.instance.DeleteKey("Music");
        
        PlayerPrefsManager.instance.DeleteKey("Sensitivity");

        PlayerPrefsManager.instance.DeleteKey("Zoom");

        PlayerPrefsManager.instance.DeleteKey("QualityIndex");

        PlayerPrefsManager.instance.DeleteKey("LanguageIndex");
    }

    private void Update()
    {
        sliderSFX.value = PlayerPrefsManager.instance.GetSFX();
        sliderMusic.value = PlayerPrefsManager.instance.GetMusic();
        sliderSensitivity.value = PlayerPrefsManager.instance.GetSensitivity();
        sliderZoom.value = PlayerPrefsManager.instance.GetZoom();
        dropdownQuality.value = PlayerPrefsManager.instance.GetQuality();
        dropdownLanguage.value = PlayerPrefsManager.instance.GetLanguage();
    }
}
