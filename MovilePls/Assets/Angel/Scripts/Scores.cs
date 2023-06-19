using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public List<TextMeshProUGUI> ScoresUI;

    // Start is called before the first frame update
    void Start()
    {
        ScoresUI[0].text = PlayerPrefs.GetInt("FinalScore1").ToString();
        ScoresUI[1].text = PlayerPrefs.GetInt("FinalScore2").ToString();
        ScoresUI[2].text = PlayerPrefs.GetInt("FinalScore3").ToString();
    }

    
}
