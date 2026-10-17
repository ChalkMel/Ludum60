using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.PhoneSystem
{
  public class DialerView : MonoBehaviour
  {
    [SerializeField] private GameObject root;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button callButton;
    [SerializeField] private Button closeButton;

    public event Action<string> OnCall;
    public bool IsOpen => root.activeSelf;

    private void Awake()
    {
      root.SetActive(false);
      callButton.onClick.AddListener(() => { OnCall?.Invoke(input.text); });
      closeButton.onClick.AddListener(Close);
    }

    public void Open() { input.text = string.Empty; root.SetActive(true); }
    public void Close() => root.SetActive(false);
  }
}