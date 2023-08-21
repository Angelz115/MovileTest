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
    private void Update()
    {
        if (lives <= 0 && GameManager2.Instance.currentState != playState.Defeat)
        {
            GameManager2.Instance.gameOver();
        }
    }
    public int subtractLIves() 
    {
        lives--;
        return lives;

    }
    public int getLivesP() 
    {
        if (lives <= 0)
        {
            lives = 0;
        }
        return lives;
    }
}
