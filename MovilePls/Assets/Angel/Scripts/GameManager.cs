using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerLife playerLife;
    public PlayerPoints playerPoints;
    public Spawner spawner;
    public bool gameEnded;

    public GameObject popUp;

    public List<TextMeshProUGUI> Values;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLife.isDead)
        {
            gameEnded = true;
        }
    }
    public void PopUp() 
    {
        popUp.SetActive(true);
        
    }
}

