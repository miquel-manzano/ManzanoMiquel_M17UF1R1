using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void OnGameResumePress()
    {
        pauseMenuUI.SetActive(false);
    }

    public void OnGameRestartPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameQuitPress()
    {
        Application.Quit();
    }

    public void OnGamePausePress()
    {
        pauseMenuUI.SetActive(true);
    }
}
