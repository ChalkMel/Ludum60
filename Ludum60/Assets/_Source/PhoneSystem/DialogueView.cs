using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.PhoneSystem
{
  public class DialogueView : MonoBehaviour
  {
    [SerializeField] private GameObject root;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button nextButton;
    [SerializeField] private TextMeshProUGUI nextButtonLabel;

    private string[] _pages;
    private int _index;

    public bool IsOpen => root != null && root.activeSelf;

    private void Awake()
    {
      nextButton.onClick.AddListener(Advance);
      root.SetActive(false);
    }

    public void Show(string[] pages)
    {
      if (pages == null || pages.Length == 0) { Close(); return; }

      _pages = pages;
      _index = 0;
      root.SetActive(true);
      RenderCurrent();
    }
    
    public void Show(string text) => Show(new[] { text });

    public void Close()
    {
      _pages = null;
      if (root != null) root.SetActive(false);
    }

    private void Advance()
    {
      if (_index < _pages.Length - 1) { _index++; RenderCurrent(); }
      else Close();
    }

    private void RenderCurrent()
    {
      label.text = _pages[_index];

      if (nextButtonLabel != null)
        nextButtonLabel.text = _index < _pages.Length - 1 ? "Next" : "Close";
    }
  }
}