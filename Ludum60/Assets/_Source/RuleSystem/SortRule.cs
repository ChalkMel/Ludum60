using _Source.Media;
using UnityEngine;

namespace _Source.RuleSystem
{
  public abstract class SortRule : MonoBehaviour
  {
    public abstract bool IsCorrect(MediaData data);
  }
}