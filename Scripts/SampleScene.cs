using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;   

public class MainScene : MonoBehaviour
{
    FlowmeterService flowmeterService;
    public int Total_consumption;
    private int hour;
    private int minutes;
    private int seconds;
    private int day;
    private int month;
    private int year;
    public InputField Instant_consumption;
    public InputField Instant_consumption2;
    public InputField Instant_consumption3;
    public InputField Instant_consumption4;
    public InputField Instant_consumption5;
    public InputField Instant_consumption6;
    

    void Start()
    {
        flowmeterService = new FlowmeterService();
        // InvokeRepeating("kurwa", 1, 1.0f);
        InvokeRepeating("onAddFlowmeter1ButtonClick", 1, 1.0f);


    }



    public void onFlowmeterTableButtonClick()
    {
        Debug.Log("Записано епт");

        flowmeterService.CreateMultipleFlowmeterTablesDB(100);
    }


    //public void deletetable()
    //{
    //    Debug.Log("ПИЗДААААААААА НАХУЙ САНЯ, БАЗА ДАННЫХ НАКРЫЛАСЬ НАХУЙ БЛЯТЬ");
    //    flowmeterService.DeleteFlowmeterTableDB(100);
    //}

    private int hui = 0;
    private float totalConsumptionSum = 0.0f;

    //public bool externalSignal = false;

    // Обновление вызывается один раз за кадр
    //void Update()
    //{

    //    if (externalSignal)
    //    {
    //        //вызываем функцию добавления данных в таблицу
    //        test testScript = GetComponent<test>();

    //        testScript.UpdateText();

    //        onAddFlowmeter1ButtonClick();
    //        externalSignal = false;
    //    }
    //}


    //public async void kurwa()
    // {

    //         Debug.Log("script active");
    //         onAddFlowmeter1ButtonClick();


    // }


    //public void onAddFlowmeter1ButtonClick()
    //{
    //    //int currentDay = 1;
    //    while (hui < 100)
    //    {
    //        System.Random rnd = new System.Random();
    //        float Instant_consumption = rnd.Next(30, 100);
    //        //year = System.DateTime.Now.Year;
    //        int year = rnd.Next(2024, 2030);
    //        int month = rnd.Next(1, 13);
    //        int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
    //        int hour = rnd.Next(0, 24);
    //        int minutes = rnd.Next(1, 59);
    //        int seconds = rnd.Next(1, 59);
    //        //int month = rnd.Next(1, 12);
    //        //int day = currentDay;
    //        //int year = rnd.Next(2023, 2028);
    //        //day = System.DateTime.Now.Day;
    //        // month = System.DateTime.Now.Month;
    //        hui++;
    //        //if (hui % 24 == 0)
    //        //{
    //        //    currentDay++;
    //        //}

    //        Debug.Log("---------onAddFlowmeterButtonClick---------");

    //        Flowmeter_11 flowmeter = new Flowmeter_11
    //        {
    //            Instant_consumption = Instant_consumption,
    //            Total_consumption = totalConsumptionSum,
    //            Year = year,
    //            Month = month,
    //            Day = day,
    //            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
    //            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
    //        };

    //        totalConsumptionSum += flowmeter.Instant_consumption;
    //        flowmeter.Total_consumption = totalConsumptionSum;
    //        int pk = flowmeterService.AddFlowmeter(flowmeter);

    //        Debug.Log("Primary key = " + pk);
    //    }
    //}

    public void onAddFlowmeter1ButtonClick()
    {

        System.Random rnd = new System.Random();
        float Instant_consumption = rnd.Next(30, 100);

        year = System.DateTime.Now.Year;
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        hour = System.DateTime.Now.Hour;
        minutes = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;

        Debug.Log("---------onAddFlowmeterButtonClick---------");

        Flowmeter_01 flowmeter1 = new Flowmeter_01
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };

        Flowmeter_02 flowmeter2 = new Flowmeter_02
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };

        Flowmeter_03 flowmeter3 = new Flowmeter_03
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };

        Flowmeter_04 flowmeter4 = new Flowmeter_04
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_05 flowmeter5 = new Flowmeter_05
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_06 flowmeter6 = new Flowmeter_06
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_07 flowmeter7 = new Flowmeter_07
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_08 flowmeter8 = new Flowmeter_08
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_09 flowmeter9 = new Flowmeter_09
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_10 flowmeter10 = new Flowmeter_10
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_11 flowmeter11 = new Flowmeter_11
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_12 flowmeter12 = new Flowmeter_12
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_13 flowmeter13 = new Flowmeter_13
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_14 flowmeter14 = new Flowmeter_14
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_15 flowmeter15 = new Flowmeter_15
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_16 flowmeter16 = new Flowmeter_16
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_17 flowmeter17 = new Flowmeter_17
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_18 flowmeter18 = new Flowmeter_18
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_19 flowmeter19 = new Flowmeter_19
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_20 flowmeter20 = new Flowmeter_20
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_21 flowmeter21 = new Flowmeter_21
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_22 flowmeter22 = new Flowmeter_22
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_23 flowmeter23 = new Flowmeter_23
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_24 flowmeter24 = new Flowmeter_24
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_25 flowmeter25 = new Flowmeter_25
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_26 flowmeter26 = new Flowmeter_26
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_27 flowmeter27 = new Flowmeter_27
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_28 flowmeter28 = new Flowmeter_28
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_29 flowmeter29 = new Flowmeter_29
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_30 flowmeter30 = new Flowmeter_30
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_31 flowmeter31 = new Flowmeter_31
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_32 flowmeter32 = new Flowmeter_32
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_33 flowmeter33 = new Flowmeter_33
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_34 flowmeter34 = new Flowmeter_34
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_35 flowmeter35 = new Flowmeter_35
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_36 flowmeter36 = new Flowmeter_36
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_37 flowmeter37 = new Flowmeter_37
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_38 flowmeter38 = new Flowmeter_38
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_39 flowmeter39 = new Flowmeter_39
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_40 flowmeter40 = new Flowmeter_40
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_41 flowmeter41 = new Flowmeter_41
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_42 flowmeter42 = new Flowmeter_42
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_43 flowmeter43 = new Flowmeter_43
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_44 flowmeter44 = new Flowmeter_44
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_45 flowmeter45 = new Flowmeter_45
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_46 flowmeter46 = new Flowmeter_46
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_47 flowmeter47 = new Flowmeter_47
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_48 flowmeter48 = new Flowmeter_48
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_49 flowmeter49 = new Flowmeter_49
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_50 flowmeter50 = new Flowmeter_50
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_51 flowmeter51 = new Flowmeter_51
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_52 flowmeter52 = new Flowmeter_52
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_53 flowmeter53 = new Flowmeter_53
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_54 flowmeter54 = new Flowmeter_54
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_55 flowmeter55 = new Flowmeter_55
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_56 flowmeter56 = new Flowmeter_56
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_57 flowmeter57 = new Flowmeter_57
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_58 flowmeter58 = new Flowmeter_58
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_59 flowmeter59 = new Flowmeter_59
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };
        Flowmeter_60 flowmeter60 = new Flowmeter_60
        {
            Instant_consumption = Instant_consumption,
            Total_consumption = totalConsumptionSum,
            Year = year,
            Month = month,
            Day = day,
            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
        };

        int pk1 = flowmeterService.AddFlowmeter(flowmeter1);
        int pk2 = flowmeterService.AddFlowmeter(flowmeter2);
        int pk3 = flowmeterService.AddFlowmeter(flowmeter3);
        int pk4 = flowmeterService.AddFlowmeter(flowmeter4);
        int pk5 = flowmeterService.AddFlowmeter(flowmeter5);
        int pk6 = flowmeterService.AddFlowmeter(flowmeter6);
        int pk7 = flowmeterService.AddFlowmeter(flowmeter7);
        int pk8 = flowmeterService.AddFlowmeter(flowmeter8);
        int pk9 = flowmeterService.AddFlowmeter(flowmeter9);
        int pk10 = flowmeterService.AddFlowmeter(flowmeter10);
        int pk11 = flowmeterService.AddFlowmeter(flowmeter11);
        int pk12 = flowmeterService.AddFlowmeter(flowmeter12);
        int pk13 = flowmeterService.AddFlowmeter(flowmeter13);
        int pk14 = flowmeterService.AddFlowmeter(flowmeter14);
        int pk15 = flowmeterService.AddFlowmeter(flowmeter15);
        int pk16 = flowmeterService.AddFlowmeter(flowmeter16);
        int pk17 = flowmeterService.AddFlowmeter(flowmeter17);
        int pk18 = flowmeterService.AddFlowmeter(flowmeter18);
        int pk19 = flowmeterService.AddFlowmeter(flowmeter19);
        int pk20 = flowmeterService.AddFlowmeter(flowmeter20);
        int pk21 = flowmeterService.AddFlowmeter(flowmeter21);
        int pk22 = flowmeterService.AddFlowmeter(flowmeter22);
        int pk23 = flowmeterService.AddFlowmeter(flowmeter23);
        int pk24 = flowmeterService.AddFlowmeter(flowmeter24);
        int pk25 = flowmeterService.AddFlowmeter(flowmeter25);
        int pk26 = flowmeterService.AddFlowmeter(flowmeter26);
        int pk27 = flowmeterService.AddFlowmeter(flowmeter27);
        int pk28 = flowmeterService.AddFlowmeter(flowmeter28);
        int pk29 = flowmeterService.AddFlowmeter(flowmeter29);
        int pk30 = flowmeterService.AddFlowmeter(flowmeter30);
        int pk31 = flowmeterService.AddFlowmeter(flowmeter31);
        int pk32 = flowmeterService.AddFlowmeter(flowmeter32);
        int pk33 = flowmeterService.AddFlowmeter(flowmeter33);
        int pk34 = flowmeterService.AddFlowmeter(flowmeter34);
        int pk35 = flowmeterService.AddFlowmeter(flowmeter35);
        int pk36 = flowmeterService.AddFlowmeter(flowmeter36);
        int pk37 = flowmeterService.AddFlowmeter(flowmeter37);
        int pk38 = flowmeterService.AddFlowmeter(flowmeter38);
        int pk39 = flowmeterService.AddFlowmeter(flowmeter39);
        int pk40 = flowmeterService.AddFlowmeter(flowmeter40);
        int pk41 = flowmeterService.AddFlowmeter(flowmeter41);
        int pk42 = flowmeterService.AddFlowmeter(flowmeter42);
        int pk43 = flowmeterService.AddFlowmeter(flowmeter43);
        int pk44 = flowmeterService.AddFlowmeter(flowmeter44);
        int pk45 = flowmeterService.AddFlowmeter(flowmeter45);
        int pk46 = flowmeterService.AddFlowmeter(flowmeter46);
        int pk47 = flowmeterService.AddFlowmeter(flowmeter47);
        int pk48 = flowmeterService.AddFlowmeter(flowmeter48);
        int pk49 = flowmeterService.AddFlowmeter(flowmeter49);
        int pk50 = flowmeterService.AddFlowmeter(flowmeter50);
        int pk51 = flowmeterService.AddFlowmeter(flowmeter51);
        int pk52 = flowmeterService.AddFlowmeter(flowmeter52);
        int pk53 = flowmeterService.AddFlowmeter(flowmeter53);
        int pk54 = flowmeterService.AddFlowmeter(flowmeter54);
        int pk55 = flowmeterService.AddFlowmeter(flowmeter55);
        int pk56 = flowmeterService.AddFlowmeter(flowmeter56);
        int pk57 = flowmeterService.AddFlowmeter(flowmeter57);
        int pk58 = flowmeterService.AddFlowmeter(flowmeter58);
        int pk59 = flowmeterService.AddFlowmeter(flowmeter59);
        int pk60 = flowmeterService.AddFlowmeter(flowmeter60);
        // totalConsumptionSum += flowmeter.Instant_consumption;
        //flowmeter.Total_consumption = totalConsumptionSum;


    }





    //public ModBus_TCP_CLIENT tcp_data1;


    //public int value_real; //Текущее значение
    //public int value_summ; //Сумматор
    //public int number_req; //номер запроса TCP
    //public int number_reg_real; //номер ячейки TCP в шлюзе
    //public int number_reg_summ; //номер ячейки TCP в шлюзе      сумматор

    //public void onAddFlowmeter1ButtonClick()
    //{

    //        System.Random rnd = new System.Random();
    //        //float Instant_consumption = rnd.Next(30, 100);
    //        int year = 2024;
    //        int month = rnd.Next(1, 13);
    //        int day = rnd.Next(1, DateTime.DaysInMonth(year, month) + 1);
    //        int hour = rnd.Next(0, 24);
    //        int minutes = rnd.Next(1, 59);
    //        int seconds = rnd.Next(1, 59);
    //        value_real = tcp_data1.RX_REGS[number_req, number_reg_real];


    //    Debug.Log("---------onAddFlowmeterButtonClick---------");

    //        Flowmeter_02 flowmeter = new Flowmeter_02
    //        {
    //            Instant_consumption = value_real,

    //            Total_consumption = totalConsumptionSum,
    //            Year = year,
    //            Month = month,
    //            Day = day,
    //            Time = hour.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2"),
    //            Date = new DateTime(year, month, day, hour, minutes, seconds).ToString("yyyy-MM-dd HH:mm:ss"),
    //        };

    //        totalConsumptionSum += flowmeter.Instant_consumption;
    //        flowmeter.Total_consumption = totalConsumptionSum;
    //        int pk = flowmeterService.AddFlowmeter(flowmeter);

    //        Debug.Log("Primary key = " + pk);

    //}

}
