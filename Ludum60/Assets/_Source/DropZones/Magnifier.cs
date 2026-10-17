using _Source.InputSystem;
using UnityEngine;

namespace _Source.DropZones
{
  public class Magnifier : MonoBehaviour, IHoldable
  {
    private Vector3 _home;
    private Collider2D _collider;

    void Awake()
    {
      _home = transform.position; 
      _collider = GetComponent<Collider2D>();
    }

    public void OnPickedUp() => _collider.enabled = false;

    public void OnDropped()
    {
      _collider.enabled = true;
      transform.position = _home;
    }
  }
}