//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class Pause : MonoBehaviour
//{
//    public static bool GameIsPasued = false;
//    public GameObject pausemenuui;
//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (GameIsPasued)
//            {
//                Resume();
//            }
//            else
//            {
//                pause();
//            }
//        }
//    }
//    public void Resume()
//    {
//        pausemenuui.SetActive(false);
//        Time.timeScale = 1f;
//        GameIsPasued = false;
//    }
//    void pause()
//    {
//        pausemenuui.SetActive(true);
//        Time.timeScale = 0f;
//        GameIsPasued = true;
//    }
//    public void LoadMenu()
//    {
//        SceneManager.LoadScene("MainScene");
//        Time.timeScale = 1f;

//    }
//    public void QuitGame()
//    {
//        Debug.Log("Quitting Game...");
//        Application.Quit();
//    }

//}