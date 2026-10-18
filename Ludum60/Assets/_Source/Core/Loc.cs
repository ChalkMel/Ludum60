namespace _Source.Core
{
  using UnityEngine.Localization.Settings;

  public static class Loc
  {
    public static string Get(string key, string table = "UI")
      => LocalizationSettings.StringDatabase.GetLocalizedString(table, key);

    public static string Get(string table, string key, params object[] args)
      => LocalizationSettings.StringDatabase.GetLocalizedString(table, key, args);
  }
}