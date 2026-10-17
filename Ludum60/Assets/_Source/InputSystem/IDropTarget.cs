using _Source.InputSystem;

namespace _Source
{
  public interface IDropTarget
  {
    void OnDrop(IHoldable held);
  }
}