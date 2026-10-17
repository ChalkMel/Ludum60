using _Source.Media;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Core
{
  public class LevelController : MonoBehaviour
  {
    public static LevelController Instance;
    [SerializeField] string nextScene;

    private int _total;
    private int _consumed;
    private EndLevel _endLevel;
    
    public void Init(EndLevel endLevel)
    {
      _endLevel = endLevel;
    }
    
    void Awake() => Instance = this;
    void Start() => _total = FindObjectsOfType<MediaItem>(true).Length; //TODO

    public void OnItemConsumed()
    {
      if (++_consumed < _total) return;
      _endLevel.Stats();
    }

    public void NextLevel()
    {
      if (!string.IsNullOrEmpty(nextScene)) SceneManager.LoadScene(nextScene);
      else Debug.Log("Game over");
    }
  }
}