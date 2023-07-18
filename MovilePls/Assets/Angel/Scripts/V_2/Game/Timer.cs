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
    // Start is called before the first frame update
    private void Start()
    {
        timer = normalTime;
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
                    changeState(GameState.Warning);
                    timer = showerTime;
                    break;

                case GameState.Warning:
                    changeState(GameState.MeteorShower);
                    timer = warningTime;
                    break;

                case GameState.MeteorShower:
                    changeState(GameState.Normal);
                    timer = buyTime;
                    break;

            }
        }
    }
    
    void changeState(GameState state) 
    {
        currentState = state;
        EndlessManager.Instance.changeState(state);
    }
    public void displayTime(float timeToDisplay) 
    {
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeToShow.text = string.Format("{0:00} : {1:00}", minutes,seconds);
    }
}
