using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scene_Change : MonoBehaviour
{
    public TextMeshProUGUI showText;
    public GameObject textGM;
    public int toLvl2, toLvl3;
    public void toMainMenu()
    {
        SceneManager.LoadScene("SelectorNivel");
    }

    public void toInicio()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    public void lvl1()
    {
        
        SceneManager.LoadScene("Level1");
    }
    public void lvl2() 
    {
        if (PlayerPrefs.GetInt("FinalScore1") > toLvl2)
        
            SceneManager.LoadScene("Level2");
        else
        {
            textGM.SetActive(true);
            textGM.GetComponent<TextInScreen>().isActive = true;
            showText.text = "Puntuacion insuficiente, nesecita un minimo de " + toLvl2;
        }
        
    }
    public void lvl3() 
    {
        if (PlayerPrefs.GetInt("FinalScore1") > toLvl3)
            SceneManager.LoadScene("Level3");
        
        else
        {
            textGM.SetActive(true);
            textGM.GetComponent<TextInScreen>().isActive = true;
            showText.text = "Puntuacion insuficiente, nesecita un minimo de " + toLvl3;
        }
    }
    public void resetScores()
    {
        PlayerPrefs.SetInt("FinalScore3", 0);
        PlayerPrefs.SetInt("FinalScore2", 0);
        PlayerPrefs.SetInt("FinalScore1", 0);
    }
}
