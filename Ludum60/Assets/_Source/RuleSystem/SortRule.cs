using _Source.Media;
using TMPro;
using UnityEngine;

namespace _Source.RuleSystem
{
  public abstract class SortRule : MonoBehaviour
  {
    public abstract void SetTitle(TextMeshProUGUI title);
    public abstract bool IsCorrect(MediaData data);
  }
}