using System.Collections.Generic;
using _Source.InputSystem;
using _Source.Media;
using UnityEngine;

namespace _Source.DropZones
{
  public class MediaStack : MonoBehaviour, IClickable, IDropTarget
  {
    [SerializeField] Transform spawnPoint;

    readonly Stack<MediaItem> _items = new();

    void Awake()
    {
      foreach (var item in GetComponentsInChildren<MediaItem>(true))
      {
        item.SetOriginStack(this);
        item.gameObject.SetActive(false);
        _items.Push(item);
      }
    }

    public int Count => _items.Count;
    
    public void OnClick()
    {
      if (_items.Count == 0) return;
      var item = _items.Pop();
      item.Restore();
      item.transform.SetParent(null, true);
      item.transform.position = spawnPoint.position;
      DragController.Instance.PickUp(item);
    }
    
    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      Stash(item);
    }

    public void Stash(MediaItem item)
    {
      item.Stash();
      item.SetOriginStack(this);
      item.transform.SetParent(transform, true);
      _items.Push(item);
    }
  }
}