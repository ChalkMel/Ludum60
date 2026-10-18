using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace _Source.Menu
{
  public class LanguageSelector : MonoBehaviour
  {
    [SerializeField] private TMP_Dropdown dropdown;
  
    private readonly string[] localeCodes = { "en", "ru" };

    private const string LangKey = "SelectedLanguage";

    private void Start()
    { int saved = PlayerPrefs.GetInt(LangKey, 0);
      dropdown.value = saved;
      dropdown.onValueChanged.AddListener(OnLanguageChanged);

      StartCoroutine(ApplyLocale(saved));
    }

    private void OnLanguageChanged(int index)
    {
      PlayerPrefs.SetInt(LangKey, index);
      PlayerPrefs.Save();
      StartCoroutine(ApplyLocale(index));
    }

    private IEnumerator ApplyLocale(int index)
    {
      yield return LocalizationSettings.InitializationOperation;

      if (index < 0 || index >= localeCodes.Length) yield break;

      var locale = LocalizationSettings.AvailableLocales.GetLocale(localeCodes[index]);
      if (locale != null)
        LocalizationSettings.SelectedLocale = locale;
    }
  }
}