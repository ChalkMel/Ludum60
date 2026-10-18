using System.Linq;
using UnityEngine.Localization;

namespace _Source.Core
{
  public static class LocalizedStringExtensions
  {
    public static string[] ResolveAll(this LocalizedString[] arr)
    {
      if (arr == null || arr.Length == 0) return System.Array.Empty<string>();
      return arr
        .Select(ls => ls == null || ls.IsEmpty
          ? string.Empty
          : ls.GetLocalizedString())
        .ToArray();
    }
  }
}