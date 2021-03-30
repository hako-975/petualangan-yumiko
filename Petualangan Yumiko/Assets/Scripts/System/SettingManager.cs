using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public AudioMixer mixerSFX;
    public AudioMixer mixerMusic;

    CinemachineCoreGetInputTouchAxis touchSensitivity;

    // GameObject
    public Slider sliderSFX;
    public Slider sliderMusic;
    public Slider sliderSensitivity;

    public TMP_Dropdown dropdownQuality;

    private void Start()
    {
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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefsManager.instance.SetQuality(qualityIndex);
    }

    public void SetDefaultSetting()
    {
        PlayerPrefsManager.instance.DeleteKey("SFX");
        PlayerPrefsManager.instance.SetSFX(-5f); // default

        PlayerPrefsManager.instance.DeleteKey("Music");
        PlayerPrefsManager.instance.SetMusic(-5f); // default

        PlayerPrefsManager.instance.DeleteKey("Sensitivity");
        PlayerPrefsManager.instance.SetSensitivity(20f); // default

        PlayerPrefsManager.instance.DeleteKey("QualityIndex");
        PlayerPrefsManager.instance.SetQuality(0); // default low quality
    }

    private void Update()
    {
        sliderSFX.value = PlayerPrefsManager.instance.GetSFX();
        sliderMusic.value = PlayerPrefsManager.instance.GetMusic();
        sliderSensitivity.value = PlayerPrefsManager.instance.GetSensitivity();
        dropdownQuality.value = PlayerPrefsManager.instance.GetQuality();
    }
}
