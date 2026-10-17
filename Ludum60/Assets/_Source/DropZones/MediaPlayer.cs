using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.NotebookSystem;
using UnityEngine;

namespace _Source.DropZones
{
  public class MediaPlayer : MonoBehaviour, IDropTarget
  {
    [SerializeField] AudioSource source;
    
    private Notebook _notebook;
    
    public void Init(Notebook notebook)
    {
      _notebook = notebook;
    }
    
    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      if (item.Data.Audio) source.PlayOneShot(item.Data.Audio);
      _notebook.Clear();
      _notebook.Add(item.Data.PlayerNote);
    }
  }
}