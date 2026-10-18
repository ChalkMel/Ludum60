using System.Collections.Generic;
using _Source.Media;
using _Source.PhoneSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Core
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] string nextScene;

    private int _total;
    private int _consumed;
    private EndLevel _endLevel;
    private Phone _phone;
    private bool _ringOnStart;
    
    public bool HasNextLevel => !string.IsNullOrEmpty(nextScene);
    public void Init(EndLevel endLevel, Phone phone, bool ringOnStart, List<MediaItem> media)
    {
      _endLevel = endLevel;
      _phone = phone;
      _ringOnStart = ringOnStart;
      _total = media.Count;
    }

    private void Start()
    {
      if (_ringOnStart) _phone?.RingForIntro();
    }

    public void OnItemConsumed()
    {
      if (++_consumed < _total) return;
      _endLevel.Stats();
    }

    public void OpenLevel()
    {
      if (!string.IsNullOrEmpty(nextScene)) SceneManager.LoadScene(nextScene);
      else Debug.Log("Game over");
    }
  }
}