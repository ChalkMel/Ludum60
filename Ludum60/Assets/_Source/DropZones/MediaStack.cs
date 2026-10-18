using System.Collections.Generic;
using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.NotebookSystem;
using UnityEngine;

namespace _Source.DropZones
{
  public class MediaStack : MonoBehaviour, IClickable, IDropTarget
  {
    [SerializeField] Transform spawnPoint;
    [SerializeField] Notebook notebook;
    [SerializeField] LevelController levelController;
    readonly Stack<MediaItem> _items = new();
    private List<MediaItem> _totalStack = new();

    public void Init()
    {
      _totalStack = new List<MediaItem>(GetComponentsInChildren<MediaItem>(true));
      foreach (var item in _totalStack)
      {
        item.Init(notebook, levelController);
        item.SetOriginStack(this);
        item.gameObject.SetActive(false);
        _items.Push(item);
      }
    }
    
    public List<MediaItem> GetTotalStack() => _totalStack;

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