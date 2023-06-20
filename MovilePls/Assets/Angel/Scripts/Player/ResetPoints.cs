using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPoints : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HasReset") == 0)
        {
            PlayerPrefs.SetInt("FinalScore3", 0);
            PlayerPrefs.SetInt("FinalScore2", 0);
            PlayerPrefs.SetInt("FinalScore1", 0);
            PlayerPrefs.SetInt("HasReset", 1);
            Debug.Log(PlayerPrefs.GetInt("FinalScore3")+" " + PlayerPrefs.GetInt("FinalScore3")+" " + PlayerPrefs.GetInt("FinalScore3"));

        }
        Debug.Log(PlayerPrefs.GetInt("HasReset"));
    }

}
