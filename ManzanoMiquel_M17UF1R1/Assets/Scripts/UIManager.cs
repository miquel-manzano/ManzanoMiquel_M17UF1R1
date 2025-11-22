using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                OnGameResumePress();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void OnGameResumePress()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void OnGameRestartPress()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameMainMenuPress()
    {
        Time.timeScale = 1f; // Ensure time scale is reset
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameQuitPress()
    {
        Application.Quit();
    }
}
