using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints2 : MonoBehaviour
{
    public int points;
    public int currentCombo, maxCombo;
    private void Start()
    {
        GameManager2.Instance.playerPointsUI.text = 0.ToString();
    }

    public int addPointsP(int add)
    {
        points += add;
        
        return points;
    }
    public void addComboP() 
    {
        
        currentCombo++;
        if (currentCombo >= maxCombo)
            maxCombo = currentCombo;
    }
    public void resetCurrentCombo() 
    {
        currentCombo = 0;
    }
    public int getPointsP() 
    {
        return points;
    }
    public int getComboP() 
    {
        return maxCombo;
    }
}
