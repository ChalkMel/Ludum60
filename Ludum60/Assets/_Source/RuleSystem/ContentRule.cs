using _Source.Media;
using UnityEngine;

namespace _Source.RuleSystem
{
  public class ContentRule : SortRule
  {
    [SerializeField] ContentCategory category;
    public override bool IsCorrect(MediaData data) => data.Content == category;
  }
}