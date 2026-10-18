using _Source.Core;
using _Source.Media;
using TMPro;
using UnityEngine;

namespace _Source.RuleSystem
{
  public class ContentRule : SortRule
  {
    [SerializeField] ContentCategory category;
    

    public override void SetTitle(TextMeshProUGUI title)
    {
      if(title != null)
        title.text = Loc.Get(category.ToString(), "Types");
    }
    public override bool IsCorrect(MediaData data) => data.Content == category;
  }
}