using _Source.Core;
using _Source.DropZones;
using _Source.InputSystem;
using _Source.NotebookSystem;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using IDropTarget = _Source.InputSystem.IDropTarget;

namespace _Source.Media
{
  public class MediaItem : MonoBehaviour, IHoldable, IDropTarget
  {
    [field:SerializeField] public MediaData Data {get; private set;}
    [SerializeField] Notebook _notebook;
    private Collider2D _collider;
    private bool _consumed;
    private bool _handledThisDrop;
    private MediaStack _originStack;

    void Awake()
    {
      _collider = GetComponent<Collider2D>();
    }

    public void OnPickedUp()
    {
      _collider.enabled = false;
    }
    public void OnDropped()
    {
      _collider.enabled = true;
    }
    
    public void Consume()
    {
      _consumed = true;
      _collider.enabled = false;
      gameObject.SetActive(false);
      LevelController.Instance.OnItemConsumed();
    }
    
    public void OnDrop(IHoldable held)
    {
      if (held is Magnifier)
        _notebook.Add(this, Data.MagnifierNote);
    }
    
    public void Stash()
    {
      _handledThisDrop = true;
      _collider.enabled = false;
      gameObject.SetActive(false);
    }

    public void Restore()
    {
      gameObject.SetActive(true);
      _collider.enabled = true;
    }

    public void SetOriginStack(MediaStack s) => _originStack = s;
  }
}