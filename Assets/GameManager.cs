using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool IsPlayerLost = false;

    public GameObject pauseMenuUI;
    public GameObject loseMenuUI;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        loseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPlayerLost)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void StartPlayerLoseManu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        IsPlayerLost = true;
        GameIsPaused = true;
        loseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    private void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void MainMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
