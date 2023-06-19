using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject manager;
    
    public void Paused() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level1");
    }
    public void mainMenu() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("SelectorNivel");
    }
    public void toLevel2() 
    { 
        
        if (manager.GetComponent<GameManager>().finalScore >= manager.GetComponent<GameManager>().toNext)
        {
            SceneManager.LoadScene("Level2");
        }
        
    }
    public void toLevel3() 
    {
        if (manager.GetComponent<GameManager>().finalScore >= manager.GetComponent<GameManager>().toNext)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
