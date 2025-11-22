using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public void Setup()
    {
        Time.timeScale = 0f; // Pause the game
        gameObject.SetActive(true);
    }
}
