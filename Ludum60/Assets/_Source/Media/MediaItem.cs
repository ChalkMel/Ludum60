using _Source.Core;
using _Source.DropZones;
using _Source.InputSystem;
using _Source.NotebookSystem;
using DG.Tweening;
using UnityEngine;
using IDropTarget = _Source.InputSystem.IDropTarget;

namespace _Source.Media
{
    public class MediaItem : MonoBehaviour, IHoldable, IDropTarget
    {
        [field:SerializeField] public MediaData Data { get; private set; }
        private Notebook _notebook;
        private Collider2D _collider;
        private Vector3 _baseScale;
        private bool _consumed;
        private bool _handledThisDrop;
        private MediaStack _originStack;
        private LevelController _levelController;

        private const float HoverScale = 1.2f;
        private const float TweenDuration = 0.2f;
        
        public void Init(Notebook notebook, LevelController levelController)
        {
            _notebook = notebook;
            _levelController = levelController;
        }
        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _baseScale = transform.lossyScale;
            GetComponent<SpriteRenderer>().sprite = Data.Sprite;
        }

        public void OnPickedUp()
        {
            _collider.enabled = false;
            _handledThisDrop = false;
            transform.DOKill();
            transform.DOScale(_baseScale * HoverScale, TweenDuration);

            if (Data != null && Data.IsSpecialCassette)
                GameSession.NotifySpecialCassettePickedUp(this);
        }

        public void OnDropped()
        {
            if (_handledThisDrop) return;
            if (!gameObject.activeInHierarchy) return;

            _collider.enabled = true;
            transform.DOKill();
            transform.DOScale(_baseScale, TweenDuration);
        }

        public void OnDrop(IHoldable held)
        {
            if (held is Magnifier)
                _notebook.Add(this, Data.MagnifierNote);
        }

        public void Consume()
        {
            if (_consumed) return;
            _consumed = true;
            _handledThisDrop = true;
            transform.DOKill();
            _collider.enabled = false;
            gameObject.SetActive(false);
            _levelController.OnItemConsumed();
        }

        public void Stash()
        {
            _handledThisDrop = true;
            transform.DOKill();
            _collider.enabled = false;
            gameObject.SetActive(false);
        }

        public void Restore()
        {
            gameObject.SetActive(true);
            _collider.enabled = true;
        }
    public void SetOriginStack(MediaStack s) => _originStack = s;
  }
}