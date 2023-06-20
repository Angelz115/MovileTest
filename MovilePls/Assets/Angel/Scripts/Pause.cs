using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject manager;
    public GameObject textInScreen;
    public bool showText;
    public float timer,stay;

    private void Update()
    {
        if (showText)
        {
            timer += Time.deltaTime;
        }
        if (timer >= stay)
        {
            textInScreen.SetActive(false);
        }
    }
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
    public void RestartLvl1()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level1");
        
    }
    public void RestartLvl2()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level2");

    }
    public void RestartLvl3()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level3");

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
        if (showText)
        {
            return;
        }
        if (manager.GetComponent<GameManager>().doesPass)
            SceneManager.LoadScene("Level2");
        else
        {
            textInScreen.SetActive(true);
            showText = true;
            
        }
        
    }
    public void toLevel3() 
    {
        if (showText)
        {
            return;
        }
        if (manager.GetComponent<GameManager>().doesPass)
            SceneManager.LoadScene("Level3");
        else
        {
            textInScreen.SetActive(true);
            showText = true;

        }
    }
    
}
