using _Source.Core;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Source.Story
{
  public class EndingView : MonoBehaviour
  {
    [SerializeField] private CanvasGroup root;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button nextButton;
    [SerializeField] private TextMeshProUGUI nextButtonLabel;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private LevelController levelController;
    private string[] _pages;
    private int _index;

    public bool IsOpen => root != null && root.alpha > 0.99f;

    private void Awake()
    {
      if (root == null || label == null || nextButton == null)
      {
        Debug.LogError($"[EndingView] Missing fields on {name}", this);
        enabled = false;
        return;
      }

      root.gameObject.SetActive(false);
      root.alpha = 0f;
      root.blocksRaycasts = false;
      root.interactable = false;

      nextButton.onClick.AddListener(Advance);
    }

    public void Show(string[] pages)
    {
      if (pages == null || pages.Length == 0) return;

      _pages = pages;
      _index = 0;
      RenderCurrent();

      root.gameObject.SetActive(true);
      root.alpha = 0f;
      root.blocksRaycasts = true;
      root.interactable = false;

      root.DOFade(1f, fadeDuration)
        .OnComplete(() => root.interactable = true);
    }

    private void Advance()
    {
      if (_index < _pages.Length - 1)
      {
        _index++;
        RenderCurrent();
      }
    }

    private void RenderCurrent()
    {
      label.text = _pages[_index];

      bool last = _index == _pages.Length - 1;
      if (nextButtonLabel != null)
        nextButtonLabel.text = last ? "Next" : "The End";
      if (last)
      {
        nextButton.onClick.AddListener(OpenMainMenu);
      }
    }
    
    public void OpenMainMenu()
    {
      SceneManager.LoadScene($"MainMenu");
    }
  }
}