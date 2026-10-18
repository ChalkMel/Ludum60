using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using DG.Tweening;
using UnityEngine;

namespace _Source.Story
{
   public class RobotHead : MonoBehaviour, IDropTarget
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Collider2D dropCollider;
        [SerializeField] private MediaData requiredCassette;
        [SerializeField] private EndingView endingView;
        [SerializeField] private EndingData endingData;

        private bool _visible;

        private void OnEnable()  => GameSession.OnSpecialCassettePickedUp += HandleCassettePickedUp;
        private void OnDisable() => GameSession.OnSpecialCassettePickedUp -= HandleCassettePickedUp;

        private void Awake()
        {
            if (sprite == null || dropCollider == null || endingView == null || endingData == null)
            {
                Debug.LogError($"[RobotHead] Missing fields on {name}", this);
                enabled = false;
                return;
            }
            Hide();
        }

        private void HandleCassettePickedUp(MediaItem item)
        {
            if (_visible) return;
            if (!GameSession.SecretNumberCalled) return;
            if (item.Data != requiredCassette) return;
            Show();
        }

        private void Show()
        {
            _visible = true;
            sprite.enabled = true;
            dropCollider.enabled = true;
            transform.DOPunchScale(Vector3.one * 0.2f, 0.4f, 1);
        }

        private void Hide()
        {
            _visible = false;
            if (sprite != null) sprite.enabled = false;
            if (dropCollider != null) dropCollider.enabled = false;
        }

        public void OnDrop(IHoldable held)
        {
            if (!_visible) return;
            if (held is not MediaItem item) return;
            if (item.Data != requiredCassette) return;

            item.Stash();
            GameSession.MarkRobotEndingTriggered();
            Hide();
            endingView.Show(endingData.RobotEndingPages);
        }
    }
}