using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife2 : MonoBehaviour
{
    public int lives;
    public int maxLives;

    private void Start()
    {
        if (lives >= maxLives)
            lives = maxLives;
        
    }

    public int subtractLIves() 
    {
        lives--;
        return lives;

    }
}
