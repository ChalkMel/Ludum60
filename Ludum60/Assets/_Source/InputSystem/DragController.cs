using UnityEngine;

namespace _Source
{
  public class DragController : MonoBehaviour
  {
    public static DragController Instance;
    public IHoldable Held { get; private set; }

    void Awake() => Instance = this;

    public void PickUp(IHoldable h) { Held = h; h.OnPickedUp(); }

    public void Drop()
    {
      if (Held == null) return; Held.OnDropped(); Held = null;
    }

    void Update()
    {
      if (Held is MonoBehaviour mb)
      {
        var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mb.transform.position = new Vector3(p.x, p.y, mb.transform.position.z);
      }
    }
  }
}