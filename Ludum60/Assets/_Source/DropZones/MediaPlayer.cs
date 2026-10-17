using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.NotebookSystem;
using UnityEngine;

namespace _Source.DropZones
{
  public class MediaPlayer : MonoBehaviour, IDropTarget, IClickable
  {
    [SerializeField] AudioSource source;
    private Notebook _notebook;
    
    private MediaItem _inserted;

    public bool IsBusy => _inserted != null;
    
    public void Init(Notebook notebook)
    {
      _notebook = notebook;
    }
    
    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      if (_inserted != null) EjectToHand();
      Insert(item);
    }
    
    public void OnClick()
    {
      if (_inserted == null) return;
      EjectToHand();
    }

    private void Insert(MediaItem item)
    {
      _inserted = item;
      
      item.transform.SetParent(transform, true);
      item.Stash();

      if (item.Data.Audio) source.PlayOneShot(item.Data.Audio);
      _notebook.Add(item.Data.PlayerNote);
    }

    private void EjectToHand()
    {
      var item = _inserted;
      _inserted = null;

      item.transform.SetParent(null, true);
      item.Restore();
      DragController.Instance.PickUp(item);
    }
  }
}