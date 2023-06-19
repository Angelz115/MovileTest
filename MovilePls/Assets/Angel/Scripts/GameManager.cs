using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerLife playerLife;
    public PlayerPoints playerPoints;
    public PlayerSkills PlayerSkills;
    public Pause pause;
    public Spawner spawner;
    public bool gameEnded;

    public GameObject popUp;

    public TextMeshProUGUI finishText;
    public List<TextMeshProUGUI> Values;
    public TextMeshProUGUI showText;
    public float timer;
    public float toShow;

    public int finalScore;
    public int toNext;
    public int scene;
    public bool doesPass;
    private void Start()
    {
        PlayerPrefs.SetInt("FinalScore2", 1);
    }
    void Update()
    {
        if (playerLife.isDead || spawner.emptyList)
            gameEnded = true;

        if (gameEnded)
            timer += Time.deltaTime;

        if (timer >= toShow)
        {
            if (playerLife.isDead)
                PopUp("Derrota");

            if (spawner.emptyList)
                PopUp("Victoria");

        }
        if (pause.showText)
        {
            showText.text = "Puntuacion insuficiente, nesecita un minimo de " + toNext;
        }
        
    }
    public void PopUp(string final) 
    {
        popUp.SetActive(true);

        finishText.text = final;
        finalScore = playerPoints.points;
        Values[0].text = playerLife.lives.ToString();
        Values[1].text = PlayerSkills.skillShieldCount.ToString();
        Values[2].text = playerPoints.enemyHits.ToString();
        finalScore += playerLife.lives + PlayerSkills.skillShieldCount + playerPoints.enemyHits;
        if (spawner.totalPoints == playerPoints.maxCombo)
        {
            Values[3].text = "Full Combo";
            finalScore *= 2;
        }
        else
        {
            Values[3].text = playerPoints.maxCombo.ToString();
            finalScore += playerPoints.maxCombo;
        }
        Values[4].text = finalScore.ToString();

        //Debug.Log("La puntuacion maxima del nivel es de: "+CalculateMaxPoints());

        switch (scene)
        {
            case 3:
                if (PlayerPrefs.GetInt("FinalScore3") < finalScore)
                    PlayerPrefs.SetInt("FinalScore3", finalScore);
                break;

            case 2:
                if (PlayerPrefs.GetInt("FinalScore2") < finalScore)
                    PlayerPrefs.SetInt("FinalScore2", finalScore);
                break;

            case 1:
                if (PlayerPrefs.GetInt("FinalScore1") < finalScore)
                    PlayerPrefs.SetInt("FinalScore1", finalScore);
                break;
            
        }

        //Debug.Log(PlayerPrefs.GetInt("FinalScore1"));
        if (finalScore >= toNext)
            doesPass = true;
        
    }

    public int CalculateMaxPoints() 
    {
        int maxValue = spawner.totalValPoints + 6 + 3 + 6;
        maxValue *= 2;
        return maxValue;
    }
}

