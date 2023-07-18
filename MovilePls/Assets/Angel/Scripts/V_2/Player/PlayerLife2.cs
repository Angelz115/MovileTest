using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife2 : MonoBehaviour
{
    public int lives;
    public int maxLives;

    private void Start()
    {
        lives = maxLives;
        GameManager2.Instance.livesCountUI.text = lives.ToString();
        
    }

    public int subtractLIves() 
    {
        lives--;
        return lives;

    }
    public int getLivesP() 
    {
        return lives;
    }
}
