using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class LocaleDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;

    IEnumerator Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        int selected = 0;
        
        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                selected = 0;
                break;
            case SystemLanguage.Chinese:
                selected = 1;
                break;
            case SystemLanguage.French:
                selected = 2;
                break;
            case SystemLanguage.German:
                selected = 3;
                break;
            case SystemLanguage.Indonesian:
                selected = 4;
                break;
            case SystemLanguage.Italian:
                selected = 5;
                break;
            case SystemLanguage.Japanese:
                selected = 6;
                break;
            case SystemLanguage.Russian:
                selected = 7;
                break;
            case SystemLanguage.Spanish:
                selected = 8;
                break;
            case SystemLanguage.Thai:
                selected = 9;
                break;
            case SystemLanguage.Vietnamese:
                selected = 10;
                break;
            default:
                selected = PlayerPrefsManager.instance.GetLanguage();
                break;
        }

        // Generate list of available Locales
        var options = new List<TMP_Dropdown.OptionData>();
        
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new TMP_Dropdown.OptionData(locale.name));
        }
        dropdown.options = options;

        dropdown.value = selected;
        dropdown.onValueChanged.AddListener(LocaleSelected);
    }

    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        PlayerPrefsManager.instance.SetLanguage(index);
    }
}