using _Source.Core;
using _Source.Media;
using TMPro;
using UnityEngine;

namespace _Source.RuleSystem
{
  public class DateRule : SortRule
  {
    [SerializeField] int minYear = 0;
    [SerializeField] int maxYear = 9999;

    public override void SetTitle(TextMeshProUGUI title)
    {
      if(title != null)
        title.text = $"{minYear}-{maxYear}";
    }
    public override bool IsCorrect(MediaData data) => data.Year >= minYear && data.Year <= maxYear;
  }
}