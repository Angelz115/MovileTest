using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public static EndlessManager Instance { get; private set; }
    [Header("Scripts")]
    public EndlessSpawner endlessSpawner;
    public PlayerSkills playerSkills;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void proyectile() 
    {
        playerSkills.shootProyectile();
    }
    public void changeState(GameState state)
    {
        endlessSpawner.gameState = state;
        float redux = endlessSpawner.maxTime;
        redux = redux - redux / 3;
        endlessSpawner.maxTime = redux;
    }

}
