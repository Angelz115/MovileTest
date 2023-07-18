using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager  Instance { get; private set; }

    [Header("Scripts")]

    public PlayerSkills2 playerSkills;

    [Space]
    [Header("Game Objects")]
    public GameObject textInScreen;

    [Header("Skills UI")]
    public TextMeshProUGUI proyectileCountUI;
    public TextMeshProUGUI shieldSKCountUI;

    [Space]
    [Header("Lives UI")]
    public TextMeshProUGUI livesCountUI;

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
    /*
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

    #region PLAYERLIVES
    public void subtractLives() 
    { 
        
    }

    #endregion
    */
}
