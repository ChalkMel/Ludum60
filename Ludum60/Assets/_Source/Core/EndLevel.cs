using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Core
{
  public class EndLevel : MonoBehaviour
  {
    [SerializeField] private GameObject endShiftPanel;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button button;
    
    private ScoreManager _scoreManager;
    private LevelController _levelController;

    public void Init(ScoreManager scoreManager, LevelController levelController)
    {
      _scoreManager = scoreManager;
      _levelController = levelController;
      button.onClick.AddListener(_levelController.NextLevel);
    }

    public void Stats()
    {
      endShiftPanel.SetActive(true);
      text.text = $"{_scoreManager.TotalSorted - _scoreManager.Errors} / {_scoreManager.TotalSorted} sorted right";
    }
  }
}