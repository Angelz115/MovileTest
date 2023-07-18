using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints2 : MonoBehaviour
{
    public int points;
    private void Start()
    {
        GameManager2.Instance.playerPointsUI.text = 0.ToString();
    }

    public int addPointsP(int add) 
    {
        int id =  points + add;
        return id;
    }
}
