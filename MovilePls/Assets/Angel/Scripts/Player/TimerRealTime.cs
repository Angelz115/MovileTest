using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerRealTime : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public static double timeUntilNextTry;
    void Awake()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        print("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        timeUntilNextTry = Convert.ToDouble(PlayerPrefs.GetString("TimeUntilString"));
        timeUntilNextTry -= difference.TotalSeconds;
        print("Tiempo restante " + timeUntilNextTry);
    }

    private void Update()
    {
        timeUntilNextTry -= Time.deltaTime;
    }

    void OnApplicationQuit()
    {
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        print("Saving this date to prefs: " + System.DateTime.Now);
        PlayerPrefs.SetString("TimeUntilString", timeUntilNextTry.ToString());
    }
}
