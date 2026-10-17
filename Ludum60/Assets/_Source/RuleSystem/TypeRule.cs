using _Source.Media;
using UnityEngine;

namespace _Source.RuleSystem
{
  public class TypeRule : SortRule
  {
    [SerializeField] MediaType type;

    public override bool IsCorrect(MediaData data)
    {
      if (data.Type == type)
        return true;
      return false;
    }
  }
}