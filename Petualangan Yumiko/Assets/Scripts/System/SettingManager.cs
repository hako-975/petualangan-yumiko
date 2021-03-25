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

    // GameObject
    public Slider sliderSFX;
    public Slider sliderMusic;

    public TMP_Dropdown dropdownQuality;

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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefsManager.instance.SetQuality(qualityIndex);
    }

    public void SetDefaultSetting()
    {
        PlayerPrefsManager.instance.DeleteKey("SFX");
        PlayerPrefsManager.instance.DeleteKey("Music");
        PlayerPrefsManager.instance.DeleteKey("QualityIndex");
    }

    private void Update()
    {
        sliderSFX.value = PlayerPrefsManager.instance.GetSFX();
        sliderMusic.value = PlayerPrefsManager.instance.GetMusic();
        dropdownQuality.value = PlayerPrefsManager.instance.GetQuality();
    }
}
