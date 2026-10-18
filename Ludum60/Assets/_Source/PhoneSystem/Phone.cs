using System.Collections.Generic;
using _Source.Core;
using _Source.InputSystem;
using _Source.Media;
using _Source.NotebookSystem;
using UnityEngine;

namespace _Source.PhoneSystem
{
    public class Phone : MonoBehaviour, IClickable
    {
        [SerializeField] private PhoneData data;
        [SerializeField] private AudioSource ringSource;

        private DialogueView _dialogue;
        private DialerView _dialer;
        private Notebook _notebook;
        private bool _hasRungToday;
        private List<MediaItem> _items;

        private void Awake()
        {
            if (ringSource == null) ringSource = GetComponent<AudioSource>();
        }

        public void Init(DialogueView dialogue, DialerView dialer, Notebook notebook, List<MediaItem> items)
        {
            _dialogue = dialogue;
            _dialer = dialer;
            _notebook = notebook;
            _dialer.OnCall += HandleCall;
            _items = items;
        }

        private void OnDestroy()
        {
            if (_dialer != null) _dialer.OnCall -= HandleCall;
        }
        
        public void RingForIntro()
        {
            _hasRungToday = true;
            ringSource.Play();
        }

        public void OnClick()
        {
            if (_dialogue.IsOpen)  { _dialogue.Close();  return; }
            if (_dialer.IsOpen)    { _dialer.Close();    return; }

            if (_hasRungToday)
            {
                ringSource.Stop();
                _hasRungToday = false;
                _dialogue.Show(data.IntroPages);
                return;
            }

            _dialer.Open();
        }

        private void HandleCall(string number)
        {
            _dialer.Close();

            if (string.IsNullOrEmpty(number)) { _dialogue.Show(data.NoNumberPages); return; }

            MediaItem match = FindItemWithNumber(number);
            if (match == null) { _dialogue.Show(data.WrongNumberPages); return; }

            if (match.Data.IsSecretNumber)
                GameSession.MarkSecretNumberCalled();

            _dialogue.Show(match.Data.PhoneTalk);
        }

        private MediaItem FindItemWithNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return null;
            foreach (var item in _items)
                if (item.Data != null && item.Data.PhoneNumber == number)
                    return item;
            return null;
        }
    }
  }