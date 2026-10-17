using UnityEngine;

namespace _Source.Media
{
  public class MediaItem : MonoBehaviour, IHoldable
  {
    private Collider2D _col;

    void Awake() => _col = GetComponent<Collider2D>();

    public void OnPickedUp()
    {
      _col.enabled = false;
    }
    public void OnDropped()
    {
      _col.enabled = true;
    }
  }
}