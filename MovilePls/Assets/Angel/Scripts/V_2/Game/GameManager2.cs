using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum playState { Playing, Pause, Dead }
public class GameManager2 : MonoBehaviour
{

    public static GameManager2 Instance { get; private set; }
    [Header("Scripts")]

    public PlayerSkills2 playerSkills;
    public PlayerLife2 playerLife;
    public PlayerPoints2 playerPoints;

    [Space]
    [Header("Game Objects")]
    public GameObject textInScreen;

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

    #region PLAYERCOLLISIONS
    public void subtractLives()
    {
        int lives = playerLife.subtractLIves();
        livesCountUI.text = lives.ToString();
    }
    public void addPoints(int add) 
    {
        int pn = playerPoints.addPointsP(add);
        playerPointsUI.text = pn.ToString();
    }
    #endregion

}
