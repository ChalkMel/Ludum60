using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using UnityEngine;

namespace _Source.DropZones
{
  public class Shredder : MonoBehaviour, IDropTarget
  {
    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      bool shouldShred = item.Data.IsBroken || item.Data.IsSuspicious;
      ScoreManager.Instance.Record(shouldShred);
      item.Consume();
    }
  }
}