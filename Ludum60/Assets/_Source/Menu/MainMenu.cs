using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Source.Menu
{
  public class MainMenu : MonoBehaviour
  {
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private bool isMainMenu;

    private void Start()
    {
      playButton.onClick.AddListener(Play);
      quitButton.onClick.AddListener(Quit);
    }
    private void Play()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quit()
    {
      Application.Quit();
    }
  }
}
