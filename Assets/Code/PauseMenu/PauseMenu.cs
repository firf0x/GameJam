using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        //при нажатии escape меняется с паузы на игру и наоборот
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    //пауза
    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }
    //продолжение
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    //выйти
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    //настройки(хз нужны или нет, если что уберешь)
    public void OptionsMenu()
    {
        Debug.Log("options");
        Time.timeScale = 1f;
        //SceneManagement.LoadScene("Options");
    }

}