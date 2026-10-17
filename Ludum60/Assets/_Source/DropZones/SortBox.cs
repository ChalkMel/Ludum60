using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.RuleSystem;
using UnityEngine;

namespace _Source.DropZones
{
  public class SortBox : MonoBehaviour, IDropTarget
  {
    [SerializeField] private SortRule rule;

    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      bool ok = rule.IsCorrect(item.Data);
      ScoreManager.Instance.Record(ok);
      item.Consume();
    }
  }
}