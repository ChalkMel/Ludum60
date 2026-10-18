using System;
using _Source.Core;
using _Source.Media;
using TMPro;
using UnityEngine;

namespace _Source.RuleSystem
{
  public class TypeRule : SortRule
  {
    [SerializeField] MediaType type;
    

   public override void SetTitle(TextMeshProUGUI title)
    {
      if(title != null)
        title.text = Loc.Get(type.ToString(), "Types");
    }

    public override bool IsCorrect(MediaData data)
    {
      if (data.Type == type)
        return true;
      return false;
    }
  }
}