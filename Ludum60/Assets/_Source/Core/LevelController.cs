using _Source.Media;
using _Source.PhoneSystem;
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
    private Phone _phone;
    private bool _ringOnStart;
    
    public void Init(EndLevel endLevel, Phone phone, bool ringOnStart)
    {
      _endLevel = endLevel;
      _phone = phone;
      _ringOnStart = ringOnStart;
    }

    private void Start()
    {
      _total = FindObjectsOfType<MediaItem>(true).Length; //TODO
      if (_ringOnStart) _phone?.RingForIntro();
    }
    
    void Awake() => Instance = this;

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