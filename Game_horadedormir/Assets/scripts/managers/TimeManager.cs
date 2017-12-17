using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour {

    private static DateTime time;
    private static DateTime timetoWin;

    Text text;
    // Use this for initialization
    void Start() {
        time = new DateTime(2016, 11, 29, 21, 0, 0);
        timetoWin = new DateTime(2016, 11, 30, 5, 0, 0);

        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update(){
        text.text = "Hora: " + time.ToString("h:mm tt");

    }

    public static void increaseTime(int minutes)
    {
        time = time.AddMinutes(minutes);
    }

    public static void decreaseTime(int minutes)
    {
        time = time.AddMinutes(-minutes);
    }

    public static bool isTime() {
        if (time > timetoWin)
        {
            return true;
        }
        else {
            return false;
        }

    }

}
