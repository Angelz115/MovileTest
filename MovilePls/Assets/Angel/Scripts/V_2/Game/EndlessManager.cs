using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public static EndlessManager Instance { get; private set; }
    [Header("Scripts")]
    public EndlessSpawner endless;
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
    public void changeState(GameState state)
    {
        endless.gameState = state;
        float redux = endless.maxTime;
        redux = redux - redux / 3;
        endless.maxTime = redux;
    }

}
