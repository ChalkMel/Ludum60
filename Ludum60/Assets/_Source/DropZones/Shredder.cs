using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using DG.Tweening;
using UnityEngine;

namespace _Source.DropZones
{
  public class Shredder : MonoBehaviour, IDropTarget
  {
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource sfx;
    private ScoreManager _scoreManager;

    public void Init(ScoreManager scoreManager )
    {
      _scoreManager = scoreManager;
    }
    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      bool shouldShred = item.Data.IsBroken || item.Data.IsSuspicious;
      _scoreManager.Record(shouldShred);
      item.Consume();
      particles.Play();
      sfx.Play();
      transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 1);
    }
  }
}