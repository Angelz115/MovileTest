using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool change;
    public GameState currentState;
    [Space]
    [Header("Flota Vals")]
    public float timer;
    public float normalTime, buyTime, showerTime, warningTime;

    public TextMeshProUGUI timeToShow;
    public GameObject textINScreen;
    // Start is called before the first frame update
    private void Start()
    {
        timer = normalTime;
        textINScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            displayTime(timer);
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            switch (currentState)
            {
                case GameState.Normal:
                    changeState(GameState.Warning,playState.Other);
                    timer = warningTime;
                    textINScreen.SetActive(true);
                    break;

                case GameState.Warning:
                    changeState(GameState.MeteorShower,playState.Playing);
                    timer = showerTime;
                    textINScreen.SetActive(false);
                    break;

                case GameState.MeteorShower:
                    changeState(GameState.Normal,playState.Playing);
                    timer = normalTime;
                    break;

            }
        }
    }
    
    void changeState(GameState state, playState playState) 
    {
        currentState = state;
        GameManager2.Instance.changeState(state);
        GameManager2.Instance.currentState = playState;
    }
    public void displayTime(float timeToDisplay) 
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeToShow.text = string.Format("{0:00} : {1:00}", minutes,seconds);
    }
}
