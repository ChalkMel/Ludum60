using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.PhoneSystem
{
 public class DialerView : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TMP_Text display;
        [SerializeField] private Button callButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button clearButton;
        [SerializeField] private Button backspaceButton;
        [SerializeField] private DigitButton[] digitButtons;
        [SerializeField] private int maxLength = 12;

        public event Action<string> OnCall;
        public bool IsOpen => root != null && root.activeSelf;

        private readonly StringBuilder _buffer = new();

        private void Awake()
        {
            if (root == null || display == null || callButton == null || closeButton == null)
            {
                Debug.LogError($"[DialerView] Не назначены обязательные поля на {name}", this);
                enabled = false;
                return;
            }

            if (root != gameObject) root.SetActive(false);

            foreach (var db in digitButtons)
            {
                if (db == null) continue;
                var digit = db.Value;
                db.Button.onClick.AddListener(() => Append(digit));
            }

            if (clearButton != null) clearButton.onClick.AddListener(ClearAll);
            if (backspaceButton != null) backspaceButton.onClick.AddListener(Backspace);

            callButton.onClick.AddListener(() => OnCall?.Invoke(_buffer.ToString()));
            closeButton.onClick.AddListener(Close);
        }

        public void Open()
        {
            ClearAll();
            root.SetActive(true);
        }

        public void Close() => root.SetActive(false);

        private void Append(string digit)
        {
            if (_buffer.Length >= maxLength) return;
            _buffer.Append(digit);
            Render();
        }

        private void Backspace()
        {
            if (_buffer.Length == 0) return;
            _buffer.Length--;
            Render();
        }

        private void ClearAll()
        {
            _buffer.Clear();
            Render();
        }

        private void Render()
        {
            if (display != null) display.text = _buffer.ToString();
        }
    }
}