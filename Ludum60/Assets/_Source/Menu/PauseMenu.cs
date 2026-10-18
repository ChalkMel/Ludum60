using UnityEngine;
using UnityEngine.UI;

namespace _Source.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private GameObject setingsMenu;
        [SerializeField] private GameObject pauseMenu;
        private bool _isPaused;
    
        private void Start()
        {
            pauseButton.onClick.AddListener(Pause);
            playButton.onClick.AddListener(Play);
            settingsButton.onClick.AddListener(OpenSetting);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                    Play();
                else
                    Pause();
            }
        }

        private void Play()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            _isPaused = false;
            setingsMenu.SetActive(false);
        }

        private void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            _isPaused = true;
        }

        private void OpenSetting()
        {
            setingsMenu.SetActive(true);
        }
    }
}
