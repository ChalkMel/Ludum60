using _Source.Media;
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
    
    void Awake() => Instance = this;
    void Start() => _total = FindObjectsOfType<MediaItem>(true).Length;

    public void OnItemConsumed()
    {
      if (++_consumed < _total) return;
      if (!string.IsNullOrEmpty(nextScene)) SceneManager.LoadScene(nextScene);
      else Debug.Log("Game over");
    }
  }
}