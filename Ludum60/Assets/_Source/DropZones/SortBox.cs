using System;
using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.RuleSystem;
using DG.Tweening;
using UnityEngine;

namespace _Source.DropZones
{
  public class SortBox : MonoBehaviour, IDropTarget
  {
    [SerializeField] private SortRule rule;
    [SerializeField] private ParticleSystem particles;

    private ScoreManager _scoreManager;

    public void Init(ScoreManager scoreManager )
    {
      _scoreManager = scoreManager;
    }

    public void OnDrop(IHoldable held)
    {
      if (held is not MediaItem item) return;
      bool ok = rule.IsCorrect(item.Data);
      _scoreManager.Record(ok);
      item.Consume();
      transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 1);
      particles.Play();
    }
  }
}