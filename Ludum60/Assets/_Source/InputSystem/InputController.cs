using UnityEngine;

namespace _Source.InputSystem
{
  public class InputController : MonoBehaviour
  {
    void Update()
    {
      if (Input.GetMouseButtonDown(0)) HandleClick();
    }

    void HandleClick()
    {
      Vector2 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      var drag = DragController.Instance;

      if (drag.Held == null)
      {
        var h = Raycast<IHoldable>(world, drag.Held);
        if (h != null) drag.PickUp(h);
      }
      else
      {
        var target = Raycast<IDropTarget>(world, drag.Held);
        target?.OnDrop(drag.Held);
        drag.Drop();
      }
    }
  
    T Raycast<T>(Vector2 pos, IHoldable ignore) where T : class
    {
      T best = null; int bestOrder = int.MinValue;
      foreach (var h in Physics2D.OverlapPointAll(pos))
      {
        if (ignore is MonoBehaviour mb && h.transform.IsChildOf(mb.transform)) continue;
        var c = h.GetComponentInParent<T>();
        if (c == null) continue;
        var sr = h.GetComponentInParent<SpriteRenderer>();
        int order = sr != null ? sr.sortingOrder : 0;
        if (order > bestOrder) { best = c; bestOrder = order; }
      }
      return best;
    }
  }
}