using UnityEngine;

namespace _Source.Media
{
  public class MediaItem : MonoBehaviour, IHoldable
  {
    private MediaData _data;
    private Collider2D _collider;

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
  }
}