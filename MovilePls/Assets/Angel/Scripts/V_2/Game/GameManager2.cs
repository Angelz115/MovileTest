using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum playState { Playing, Pause, Dead, Ended }
public class GameManager2 : MonoBehaviour
{

    public static GameManager2 Instance { get; private set; }
    [Header("Scripts")]
    public EndlessSpawner endlessSpawner;
    public PlayerSkills2 playerSkills;
    public PlayerLife2 playerLife;
    public PlayerPoints2 playerPoints;

    [Space]
    [Header("Variables")]
    public playState currentState;

    [Space]
    [Header("Game Objects")]
    public GameObject textInScreen;
    public GameObject blackScreen;
    public GameObject pauseMenu;

    [Space]
    [Header("Skills UI")]
    public TextMeshProUGUI proyectileCountUI;
    public TextMeshProUGUI shieldSKCountUI;

    [Space]
    [Header("Lives & Points UI")]
    public TextMeshProUGUI livesCountUI;
    public TextMeshProUGUI playerPointsUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region SKILLUI
    public void ProyectileUI()
    {
        int count = playerSkills.proyectileSK();
        proyectileCountUI.text = count.ToString();
    }
    public void ShieldSKUI()
    {
        int count = playerSkills.ShieldSK();
        shieldSKCountUI.text = count.ToString();
    }
    #endregion

    #region LIVES
    public void subtractLives()
    {
        int lives = playerLife.subtractLIves();
        livesCountUI.text = lives.ToString();
    }
    public int getLives() 
    {
        int lives = playerLife.getLivesP();
        return lives;
    }
    #endregion

    #region PAUSE

    public void paused() 
    {
        currentState = playState.Pause;
        Time.timeScale = 0;
        blackScreen.SetActive(true);
        pauseMenu.SetActive(true);
    }
    public void resume() 
    {
        currentState = playState.Playing;
        Time.timeScale = 1;
        blackScreen.SetActive(false);
        pauseMenu.SetActive(false);
    }

    #endregion

    #region POINTS
    public void addPoints(int add) 
    {
        int pn = playerPoints.addPointsP(add);
        playerPointsUI.text = pn.ToString();
    }
    public void addCombo() 
    {
        playerPoints.addComboP();
    }
    public void resetCombo() 
    {
        playerPoints.resetCurrentCombo();
    }
    public int getPoints() 
    {
        int point = playerPoints.getPointsP();
        return point;
    }
    public int getCombo() 
    {
        int combo = playerPoints.getComboP();
        return combo;
    }
    #endregion

    #region ENDLESS
    public void changeState(GameState state)
    {
        endlessSpawner.gameState = state;
        float redux = endlessSpawner.maxTime;
        redux = redux - redux / 3;
        endlessSpawner.maxTime = redux;
    }

    #endregion

}
