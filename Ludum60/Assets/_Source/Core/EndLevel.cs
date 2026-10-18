using _Source.Story;
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
    [SerializeField] private EndingView endingView;
    [SerializeField] private EndingData endingData;

    private ScoreManager _scoreManager;
    private LevelController _levelController;

    public void Init(ScoreManager scoreManager, LevelController levelController)
    {
      _scoreManager = scoreManager;
      _levelController = levelController;
      button.onClick.AddListener(HandleNext);
    }

    public void Stats()
    {
      endShiftPanel.SetActive(true);
      text.text = $"{_scoreManager.TotalSorted - _scoreManager.Errors} / {_scoreManager.TotalSorted} sorted right";
    }

    private void HandleNext()
    {
      bool isFinalDay = !_levelController.HasNextLevel;

      if (isFinalDay && !GameSession.RobotEndingTriggered)
      {
        endingView.Show(endingData.DefaultEndingPages);
        return;
      }

      _levelController.OpenLevel();
    }
  }
}