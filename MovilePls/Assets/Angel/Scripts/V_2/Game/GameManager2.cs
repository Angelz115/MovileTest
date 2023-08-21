using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum playState { Playing, Pause, Defeat, Victory,Other }
public enum gameType {Normal, Endlees }
public class GameManager2 : MonoBehaviour
{

    public static GameManager2 Instance { get; private set; }
    [Header("Scripts")]
    public EndlessSpawner endlessSpawner;
    public SpawnerV2 spawner;
    public PlayerSkills2 playerSkills;
    public PlayerLife2 playerLife;
    public PlayerPoints2 playerPoints;

    [Space]
    [Header("Variables")]
    public playState currentState;
    public gameType type;
    public bool tutorial;
    [Space]
    [Header("Game Objects")]
    public GameObject textInScreen;
    public TextMeshProUGUI tutorialText;
    public GameObject blackScreen;
    public GameObject pauseMenu;
    public GameObject popUp;
    public GameObject shield;
    public GameObject proyectileButton;
    public GameObject shieldButton;

    [Space]
    [Header("Skills UI")]
    public TextMeshProUGUI proyectileCountUI;
    public TextMeshProUGUI shieldSKCountUI;

    [Space]
    [Header("Lives & Points UI")]
    public TextMeshProUGUI livesCountUI;
    public TextMeshProUGUI playerPointsUI;

    [Space]
    [Header("PopUp")]
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI livesPopUp;
    public TextMeshProUGUI shieldPopUp;
    public TextMeshProUGUI proyectilePopUp;
    public TextMeshProUGUI comboPopUp;
    public TextMeshProUGUI ScorePopUp;
    public int changes;
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
        tutorial = playerSkills.tutorial;
        if (tutorial)
        {
            shield.SetActive(false);
            proyectileButton.SetActive(false);
            shieldButton.SetActive(false);
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
    public void gameOver() 
    {
        currentState = playState.Defeat;
        setPopUp("Derrota");
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
    public void addHitted() 
    {
        playerSkills.asteroidsHit++;
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
    public void Victory() 
    {
        currentState = playState.Victory;
        setPopUp("Victoria");
    }
    #endregion

    #region ENDLESS
    public void changeState(GameState state)
    {
        endlessSpawner.gameState = state;
        float redux = endlessSpawner.maxTime;
        redux  -= 0.1f;
        endlessSpawner.maxTime = redux;
        if (state == GameState.Normal)
        {
            changes++;
        }
    }

    #endregion
    #region TUTORIAL
    public void text(string tex) 
    {
        textInScreen.SetActive(true);
        tutorialText.text = tex;
    }
    public void turnDownText()
    {
        textInScreen.SetActive(false);
    }
    public void activateShield() 
    {
        shield.SetActive(true);
    }
    public void activateProyectiles() 
    {
        proyectileButton.SetActive(true);
    }
    public void ativateshieldButton() 
    {
        shieldButton.SetActive(true);
    }
    #endregion
    #region POPUP

    public void setPopUp(string fntext)
    {

        popUp.SetActive(true);
        int lives = playerLife.getLivesP();
        int shield = playerSkills.getShieldSKP();
        int proyectile = playerSkills.getHittedP();
        int playerCombo = playerPoints.getComboP();

        finalText.text = fntext;
        livesPopUp.text = lives.ToString();
        shieldPopUp.text = shield.ToString();
        proyectilePopUp.text = proyectile.ToString();

        if (type == gameType.Normal)
        {

            int maxCombo = spawner.getAllPoints();
            

            if (maxCombo == playerCombo)
            {
                comboPopUp.text = "Combo Maximo";
                playerCombo += Mathf.FloorToInt(playerCombo / 2);
            }
            else
            {
                comboPopUp.text = playerCombo.ToString();
            }

            int finalScore = lives + shield + proyectile + playerCombo;
            ScorePopUp.text = finalScore.ToString();
            PlayerPrefs.SetInt("monedasTotales", finalScore);
            return;
        }
        else if (type == gameType.Endlees)
        {
            int totalCombo = playerCombo + changes;
            int finalScoreEnd = lives + shield + proyectile + totalCombo;
            ScorePopUp.text = finalScoreEnd.ToString();
            PlayerPrefs.SetInt("monedasTotales", finalScoreEnd);
        }

    }

    #endregion
    private void OnApplicationQuit()
    {
        int points = playerPoints.getPointsP(); 
        PlayerPrefs.SetInt("monedasTotales", points);
    }
}
