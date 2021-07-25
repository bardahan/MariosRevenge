//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System;

//public class LoseMenu : MonoBehaviour
//{
//    public static bool GameIsPaused = false;

//    public GameObject pauseMenuUI;

//    private void Awake()
//    {
//        pauseMenuUI.SetActive(false);
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (GameIsPaused)
//            {
//                Resume();
//            }
//            else
//            {
//                Pause();
//            }
//        }
//    }

//    public void StartPlayerLoseManu()
//    {
//        pauseMenuUI.SetActive(true);
//        Time.timeScale = 0;
//        GameIsPaused = true;
//    }

//    private void Pause()
//    {
//        pauseMenuUI.SetActive(true);
//        Time.timeScale = 0;
//        GameIsPaused = true;
//    }

//    private void Resume()
//    {
//        pauseMenuUI.SetActive(false);
//        Time.timeScale = 1;
//        GameIsPaused = false;
//    }

//    public void MainMenuPressed()
//    {
//        SceneManager.LoadScene(0);
//    }
//}
