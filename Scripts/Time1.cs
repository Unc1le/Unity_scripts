using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time1 : MonoBehaviour
{
    public GameObject display;
    public GameObject display1;
    public int hour;
    public int minutes;
    public int seconds;
    public int day;
    public int month;
    public int year;
        

    void Update()
    {
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        display1.GetComponent<Text>().text = day.ToString("D2") + "." + month.ToString("D2") + "." + year.ToString("D2");
        display.GetComponent<Text>().text = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }


}
