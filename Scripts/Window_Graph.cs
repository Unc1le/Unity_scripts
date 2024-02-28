using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.UIElements;
using SQLite4Unity3d;
using System.IO;
using Button = UnityEngine.UI.Button;
using static Window_Graph;

public class Window_Graph : MonoBehaviour
{

    public GameObject instance;

    [SerializeField] 
    private Texture circleTexture;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;
    private RectTransform lineHigh;
    private RectTransform lineLow;
    private List<GameObject> gameObjectList;

    public InputField startDayInput;
    public InputField endDayInput;
    public InputField startMonthInput;
    public InputField endMonthInput;
    public InputField startYearInput;
    public InputField endYearInput;
    public InputField startDayInput2;
    public InputField endDayInput2;
    public InputField startMonthInput2;
    public InputField endMonthInput2;
    public Text logdate;
    public Text loginfodate;
    public GameObject loginfodate_panel;
    public GameObject logdate_panel;

    public int LowLevel;
    public int HighLevel;

    public Button listButton; 
    public Button dayButton; 
    public Button weekButton; 
    public Button monthButton; 
    public Button yearButton; 
    public Button resetButton; 
    string currentTableName = "Flowmeter";
    private bool isGraphCreated = false;

    private void Awake()
    {
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        //lineHigh = graphContainer.Find("lineHigh").GetComponent<RectTransform>();
        //lineLow = graphContainer.Find("lineLow").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();

       
        List<float> valueList = new List<float>();
        List<string> dateList = new List<string>();

        if (valueList.Count > 0 && dateList.Count > 0)
        {
            ShowGraph(valueList, -1, (int _i) => dateList[_i], (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        }
    }

    void Start()
    {

        dayButton.onClick.AddListener(() => OnMenuButtonClicked(dayButton));
        weekButton.onClick.AddListener(() => OnMenuButtonClicked(weekButton));
        monthButton.onClick.AddListener(() => OnMenuButtonClicked(monthButton));
        yearButton.onClick.AddListener(() => OnMenuButtonClicked(yearButton));

        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void OnMenuButtonClicked(Button buttonClicked)
    {

        listButton.GetComponentInChildren<Text>().text = buttonClicked.GetComponentInChildren<Text>().text;
    }

 
    public void clearchart()
    {
        foreach (GameObject gameObject in gameObjectList)
        {

            Destroy(gameObject);
        }
        gameObjectList.Clear();
        isGraphCreated = false;

    }

    public void drawinterval()
    {
        if (isGraphCreated)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                Destroy(gameObject);
            }
            gameObjectList.Clear();
            isGraphCreated = false;
        }
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();
        List<float> valueintList = LoadDateInterval();
        List<string> dateList = LoadDate2FromDatabase();

        ShowGraph(valueintList, -1, (int _i) => dateList[_i], (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        isGraphCreated = true;


        if (dateList.Count > 0)
        {
            string firstDate = dateList[0];
            string lastDate = dateList[dateList.Count - 1];

            // Преобразование числовых значений месяцев в текстовые
            string[] monthNames = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            string[] firstDateParts = firstDate.Split('.');
            string[] lastDateParts = lastDate.Split('.');
            firstDate = firstDateParts[0] + " " + monthNames[int.Parse(firstDateParts[1]) - 1];
            lastDate = lastDateParts[0] + " " + monthNames[int.Parse(lastDateParts[1]) - 1];

            loginfodate.text = "Данные за период с " + firstDate + " по " + lastDate;
            loginfodate_panel.SetActive(true);
        }
    }
   
    private List<string> LoadDate2FromDatabase()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<string>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            var table = db.Table<Flowmeter>();
            List<string> values = new List<string>();
            string StartDay_str = startDayInput.text.ToString();
            string EndDay_str = endDayInput.text.ToString();
            string StartMonth_str = startMonthInput.text.ToString();
            string EndMonth_str = endMonthInput.text.ToString();
            string StartYear_str = startYearInput.text.ToString();
            string EndYear_str = endYearInput.text.ToString();

            int startDayValue = int.Parse(StartDay_str);
            int startMonthValue = int.Parse(StartMonth_str);
            int endDayValue = int.Parse(EndDay_str);
            int endMonthValue = int.Parse(EndMonth_str);
            int endYearValue = int.Parse(EndYear_str);
            int startYearValue = int.Parse(StartYear_str);
            IEnumerator ShowAndHide(GameObject logdate_panel, float delay)
            {
                logdate_panel.SetActive(true);
                yield return new WaitForSeconds(delay);
                logdate_panel.SetActive(false);
            }
            if (!int.TryParse(StartDay_str, out startDayValue) || startDayValue < 1 || startDayValue > 31 && !int.TryParse(EndDay_str, out endDayValue) || endDayValue < 1 || endDayValue > 31)
            {
                logdate_panel.gameObject.SetActive(true);

                logdate.text = "Неправильно введена дата. Проверьте правильность введенных данных.";
                StartCoroutine(ShowAndHide(logdate_panel, 2));
                return new List<string>();
            }


            if (!int.TryParse(StartMonth_str, out startMonthValue) || startMonthValue < 1 || startMonthValue > 12 && !int.TryParse(EndMonth_str, out endMonthValue) || endMonthValue < 1 || endMonthValue > 12)
            {
                logdate_panel.gameObject.SetActive(true);

                logdate.text = "Неправильно введена дата. Проверьте правильность введенных данных.";
                StartCoroutine(ShowAndHide(logdate_panel, 2));

                return new List<string>();

            }


            if (!int.TryParse(StartYear_str, out startYearValue) || startYearValue < 1970 || startYearValue > 2077 && !int.TryParse(EndYear_str, out endYearValue) || endYearValue < 1970 || endYearValue > 2077)
            {
                logdate_panel.gameObject.SetActive(true);

                logdate.text = "Неправильно введена дата. Проверьте правильность введенных данных.";
                StartCoroutine(ShowAndHide(logdate_panel, 2));

                return new List<string>();
            }

            DateTime startDate = new DateTime(startYearValue, startMonthValue, startDayValue);
            DateTime endDate = new DateTime(endYearValue, endMonthValue, endDayValue);
            TimeSpan diff = endDate - startDate;
            string sqlExpression = string.Empty;


            switch (diff.TotalDays)
            {
                case var days when days >= 1 && days <= 5:
                    sqlExpression = $"SELECT strftime('%Y', Date) AS Year, strftime('%m', Date) AS Month, strftime('%d', Date) AS Day, strftime('%H', Date) AS Hour, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Day, Hour ORDER BY Day, Hour;";
                    break;
                case var days when days > 5 && days <= 50:
                    sqlExpression = $"SELECT Year, Month, Day, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month, Day;";
                    break;
                case var days when days > 50:
                    sqlExpression = $"SELECT Year, Month, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month;";
                    break;
            }


            //if((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue >= 0) && (endDayValue - startDayValue <= 5))
            //{
            //    sqlExpression = $"SELECT strftime('%Y', Date) AS Year, strftime('%m', Date) AS Month, strftime('%d', Date) AS Day, strftime('%H', Date) AS Hour, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Day, Hour  ORDER BY Year, Month, Day, Hour;";
            //}
            //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 5) && (endDayValue - startDayValue <= 50))
            //{
            //    sqlExpression = $"SELECT Year, Month, Day, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month, Day;";
            //}
            //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 50))
            //{
            //    sqlExpression = $"SELECT Year, Month, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month;";
            //}

            //if ((diff.TotalDays >= 1) && (diff.TotalDays <= 5))
            //{
            //    sqlExpression = $"SELECT strftime('%Y', Date) AS Year, strftime('%m', Date) AS Month, strftime('%d', Date) AS Day,     strftime('%H', Date) AS Hour,      strftime('%H', Date) AS Hour,     AVG(Instant_consumption) AS average_value   FROM Flowmeter1  GROUP BY Day, Hour  ORDER BY Day, Hour;  ";

            //}

            //if ((diff.TotalDays > 5) && (diff.TotalDays <= 50))
            //{
            //    sqlExpression = $"SELECT Year, Month, Day,  AVG(Instant_consumption) AS average_value FROM Flowmeter1 GROUP BY Year, Month, Day;";
            //}
            //if (diff.TotalDays > 50)
            //{
            //    sqlExpression = $"SELECT     Year, Month,  AVG(Instant_consumption) AS average_value  FROM     Flowmeter1  GROUP BY    Year, Month;";
            //}


            var results = dB.Query<anal>(sqlExpression);
            float dayMonthValue;



            foreach (var result in results)
            {


                if ((result.Year > startYearValue || (result.Year == startYearValue && (result.Month > startMonthValue || (result.Month == startMonthValue && result.Day >= startDayValue)))) &&
        (result.Year < endYearValue || (result.Year == endYearValue && (result.Month < endMonthValue || (result.Month == endMonthValue && result.Day <= endDayValue)))))
                {
                    if ((diff.TotalDays >= 1) && (diff.TotalDays <= 5))
                    {
                        values.Add(result.Day + "." + result.Month + " / " + result.Hour + " ч.");
                    }


                    if ((diff.TotalDays > 5) && (diff.TotalDays <= 50))
                    {
                        values.Add(result.Day + "." + result.Month);
                    }
                    if (diff.TotalDays > 50)
                    {
                        values.Add(result.Month + "." + result.Year);
                    }



                    //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue >= 0) && (endDayValue - startDayValue <= 5))
                    //{
                    //    values.Add(result.Day + "." + result.Month + " / " + result.Hour + " ч.");
                    //}
                    //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 5) && (endDayValue - startDayValue <= 50))
                    //{
                    //    values.Add(result.Day + "." + result.Month);
                    //}
                    //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 50))
                    //{
                    //    values.Add(result.Month + "." + result.Year);
                    //}


                }
               
            }


            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<string>();
        }
    }

    private List<float> LoadDateInterval()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<float>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            var table = db.Table<Flowmeter>();
            List<float> values = new List<float>();


            string StartDay_str = startDayInput.text.ToString();
            string EndDay_str = endDayInput.text.ToString();
            string StartMonth_str = startMonthInput.text.ToString();
            string EndMonth_str = endMonthInput.text.ToString();
            string StartYear_str = startYearInput.text.ToString();
            string EndYear_str = endYearInput.text.ToString();

            int startDayValue = int.Parse(StartDay_str);
            int startMonthValue = int.Parse(StartMonth_str);
            int endDayValue = int.Parse(EndDay_str);
            int endMonthValue = int.Parse(EndMonth_str);
            int endYearValue = int.Parse(EndYear_str);
            int startYearValue = int.Parse(StartYear_str);


            DateTime startDate = new DateTime(startYearValue, startMonthValue, startDayValue);
            DateTime endDate = new DateTime(endYearValue, endMonthValue, endDayValue);
            TimeSpan diff = endDate - startDate;
            string sqlExpression = string.Empty;

            if ((diff.TotalDays >= 1) && (diff.TotalDays <= 5))
            {
                sqlExpression = $"SELECT strftime('%Y', Date) AS Year, strftime('%m', Date) AS Month, strftime('%d', Date) AS Day,     strftime('%H', Date) AS Hour,      strftime('%H', Date) AS Hour,     AVG(Instant_consumption) AS average_value   FROM {currentTableName}  GROUP BY Day, Hour  ORDER BY Day, Hour;  ";

            }

            if ((diff.TotalDays > 5) && (diff.TotalDays <= 50))
            {
                sqlExpression = $"SELECT Year, Month, Day,  AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month, Day;";
            }
            if (diff.TotalDays > 50)
            {
                sqlExpression = $"SELECT     Year, Month,  AVG(Instant_consumption) AS average_value  FROM  {currentTableName}  GROUP BY    Year, Month;";
            }


            //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue >= 0) && (endDayValue - startDayValue <= 5))
            //{
            //    sqlExpression = $"SELECT strftime('%Y', Date) AS Year, strftime('%m', Date) AS Month, strftime('%d', Date) AS Day, strftime('%H', Date) AS Hour, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Day, Hour  ORDER BY Year, Month, Day, Hour;";
            //}
            //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 5) && (endDayValue - startDayValue <= 50))
            //{
            //    sqlExpression = $"SELECT Year, Month, Day, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month, Day;";
            //}
            //if ((endYearValue - startYearValue >= 0) && (endMonthValue - startMonthValue >= 0) && (endDayValue - startDayValue > 50))
            //{
            //    sqlExpression = $"SELECT Year, Month, AVG(Instant_consumption) AS average_value FROM {currentTableName} GROUP BY Year, Month;";
            //}

            var results = dB.Query<anal>(sqlExpression);
            float dayMonthValue;




            foreach (var result in results)
            {
                if ((result.Year > startYearValue || (result.Year == startYearValue && (result.Month > startMonthValue || (result.Month == startMonthValue && result.Day >= startDayValue)))) &&
         (result.Year < endYearValue || (result.Year == endYearValue && (result.Month < endMonthValue || (result.Month == endMonthValue && result.Day <= endDayValue)))))
                {
                    values.Add(result.average_value);
                }
            }


            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<float>();
        }
    }

    public class anal
    {
        public float Day { get; set; }
        public float Month { get; set; }
        public float Year { get; set; }
        public float average_value { get; set; }
        public float Hour { get; set; }
    }


    
    public Dropdown dropdown;
    Dictionary<string, string> optionToElement = new Dictionary<string, string>()
 {
    {"ТРЕНДЫ 1", "Flowmeter"},
    {"ТРЕНДЫ 2", "Flowmeter_01"},
    {"ТРЕНДЫ 3", "Flowmeter_02"},
    {"ТРЕНДЫ 4", "Flowmeter_03"},
    {"ТРЕНДЫ 5", "Flowmeter_04"},
    {"ТРЕНДЫ 6", "Flowmeter_05"},
    {"ТРЕНДЫ 7", "Flowmeter_06"},
    {"ТРЕНДЫ 8", "Flowmeter_07"},
    
 };
    void DropdownValueChanged(Dropdown change)
    {
        // Получите текст выбранного option
        string optionText = change.options[change.value].text;

        // Используйте словарь для получения соответствующего названия элемента
        if (optionToElement.TryGetValue(optionText, out string elementName))
        {
            currentTableName = elementName;
        }
        else
        {
            Debug.Log("Element name not found for option: " + optionText);
        }

        LoadDateDayAvg();
        DrawDay();
    }

    public void dayavg()
    {
        if (isGraphCreated)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                Destroy(gameObject);
            }
            gameObjectList.Clear();
            isGraphCreated = false;
        }
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        lineHigh = graphContainer.Find("lineHigh").GetComponent<RectTransform>();
        lineLow = graphContainer.Find("lineLow").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();
        List<float> valueList = DrawDay();
        List<string> dateList = LoadDateDayAvg();

        if (valueList.Count > 0 && dateList.Count > 0)
        {
            ShowGraph(valueList, -1, (int _i) => dateList[_i] + " ч.", (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        }
        isGraphCreated = true;
    }

    private List<string> LoadDateDayAvg()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<string>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            //string currentTableName = "Flowmeter";
            //var table = db.Table<Flowmeter>();
            List<string> values = new List<string>();
            int currentDate = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            string sqlExpression = $"SELECT strftime('%H', Date) AS hour, CAST(AVG(Instant_consumption) AS FLOAT) AS average_value FROM {currentTableName} WHERE Day = '{currentDate}' AND Month = '{currentMonth}' AND Year = '{currentYear}' GROUP BY hour;";
            var results = dB.Query<Result>(sqlExpression);
            foreach (var result in results)
            {
                
                    values.Add(result.hour);
                
            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<string>();
        }
    }

    private List<float> DrawDay()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<float>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            int currentDate = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            //string currentTableName = "Flowmeter";

            string sqlExpression = $"SELECT strftime('%H', Date) AS hour, CAST(AVG(Instant_consumption) AS FLOAT) AS average_value FROM {currentTableName} WHERE Day = '{currentDate}' AND Month = '{currentMonth}' AND Year = '{currentYear}' GROUP BY hour;";
            var results = dB.Query<Result>(sqlExpression);

            List<float> values = new List<float>();
            foreach (var result in results)
            {
                values.Add(result.average_value);
            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<float>();
        }
    }

    public class Result
    {
        public string hour { get; set; }
        public float average_value { get; set; }
    }

 


    public void weekavg()
    {
        if (isGraphCreated)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                Destroy(gameObject);
            }
            gameObjectList.Clear();
            isGraphCreated = false;
        }
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        lineHigh = graphContainer.Find("lineHigh").GetComponent<RectTransform>();
        lineLow = graphContainer.Find("lineLow").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();
        List<float> valueList = DrawWeek();
        List<string> dateList = LoadDateWeekAvg();

        if (valueList.Count > 0 && dateList.Count > 0)
        {
            ShowGraph(valueList, -1, (int _i) => dateList[_i] + " д.", (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        }
        isGraphCreated = true;
    }

    private List<string> LoadDateWeekAvg()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<string>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            var table = db.Table<Flowmeter>();
            List<string> values = new List<string>();
             string currentDate = DateTime.Now.ToString();
             string sevenDaysAgo = DateTime.Now.AddDays(-7).ToString();
             string sqlExpression = $"SELECT    Year, Month, Day,    AVG(Instant_consumption) AS average_value FROM  {currentTableName} WHERE      Date BETWEEN date('now','-7 days') AND date('now') GROUP BY      Year, Month, Day;";
            var results = dB.Query<WeekAVG>(sqlExpression);
            foreach (var result in results)
            {

                values.Add(result.Day);

            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<string>();
        }
    }

    private List<float> DrawWeek()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<float>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            string currentDate = DateTime.Now.ToString();
            string sevenDaysAgo = DateTime.Now.AddDays(-7).ToString();
            string sqlExpression = $"SELECT    Year, Month, Day,    AVG(Instant_consumption) AS average_value FROM  {currentTableName} WHERE      Date BETWEEN date('now','-7 days') AND date('now') GROUP BY      Year, Month, Day;";
            var results = dB.Query<WeekAVG>(sqlExpression);

            List<float> values = new List<float>();
            foreach (var result in results)
            {
                values.Add(result.average_value);
            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<float>();
        }
    }

    public class WeekAVG
    {
        public string Day { get; set; }
        public float average_value { get; set; }
    }







    public void monthavg()
    {
        if (isGraphCreated)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                Destroy(gameObject);
            }
            gameObjectList.Clear();
            isGraphCreated = false;
        }
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        lineHigh = graphContainer.Find("lineHigh").GetComponent<RectTransform>();
        lineLow = graphContainer.Find("lineLow").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();
        List<float> valueList = DrawMonth();
        List<string> dateList = LoadDateMonthAvg();

        if (valueList.Count > 0 && dateList.Count > 0)
        {
            ShowGraph(valueList, -1, (int _i) => dateList[_i], (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        }
        isGraphCreated = true;
    }

    private List<string> LoadDateMonthAvg()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<string>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            var table = db.Table<Flowmeter>();
            List<string> values = new List<string>();
            string currentDate = DateTime.Now.ToString();
            string sevenDaysAgo = DateTime.Now.AddDays(-30).ToString();
            string sqlExpression = $"SELECT     Year, Month, Day,    AVG(Instant_consumption) AS average_value FROM  {currentTableName} WHERE      Date BETWEEN date('now','-30 days') AND date('now') GROUP BY      Year, Month, Day; ";
            var results = dB.Query<MonthAVG>(sqlExpression);
            foreach (var result in results)
            {

                values.Add(result.Day + "." + result.Month);

            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<string>();
        }
    }

    private List<float> DrawMonth()






    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<float>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            string currentDate = DateTime.Now.ToString();
            string sevenDaysAgo = DateTime.Now.AddDays(-30).ToString();
            string sqlExpression = $"SELECT     Year, Month, Day,    AVG(Instant_consumption) AS average_value FROM   {currentTableName} WHERE      Date BETWEEN date('now','-30 days') AND date('now') GROUP BY      Year, Month, Day; ";
            var results = dB.Query<MonthAVG>(sqlExpression);

            List<float> values = new List<float>();
            foreach (var result in results)
            {
                values.Add(result.average_value);
            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<float>();
        }
    }

    public class MonthAVG
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public float average_value { get; set; }
    }






    public void yearavg()
    {
        if (isGraphCreated)
        {
            foreach (GameObject gameObject in gameObjectList)
            {
                Destroy(gameObject);
            }
            gameObjectList.Clear();
            isGraphCreated = false;
        }
        graphContainer = instance.transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();
        lineHigh = graphContainer.Find("lineHigh").GetComponent<RectTransform>();
        lineLow = graphContainer.Find("lineLow").GetComponent<RectTransform>();

        gameObjectList = new List<GameObject>();
        List<float> valueList = DrawYear();
        List<string> dateList = LoadDateYearAvg();

        if (valueList.Count > 0 && dateList.Count > 0)
        {
            ShowGraph(valueList, -1, (int _i) => dateList[_i] + " м.", (float _f) => Mathf.RoundToInt(_f) + " м³/ч");
        }
        isGraphCreated = true;
    }

    private List<string> LoadDateYearAvg()
    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<string>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

            var table = db.Table<Flowmeter>();
            List<string> values = new List<string>();
            string currentYear = DateTime.Now.Year.ToString();
            
            string sqlExpression = $"SELECT     Month,    AVG(Instant_consumption) AS average_value FROM   {currentTableName} WHERE     Year = '{currentYear}' GROUP BY     Month ORDER BY      Month;";
            var results = dB.Query<YearAVG>(sqlExpression);
            foreach (var result in results)
            {

                values.Add(result.Month);

            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<string>();
        }
    }

    private List<float> DrawYear()






    {
        string DatabaseName = "Flowmeter.db";
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
        var db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        if (!File.Exists(dbPath))
        {
            Debug.LogError("Database file not found at path: " + dbPath);
            return new List<float>();
        }

        try
        {
            var dB = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            string currentYear = DateTime.Now.Year.ToString();

            string sqlExpression = $"SELECT     Month,    AVG(Instant_consumption) AS average_value FROM   {currentTableName} WHERE     Year = '{currentYear}' GROUP BY     Month ORDER BY      Month;";
            var results = dB.Query<YearAVG>(sqlExpression);

            List<float> values = new List<float>();
            foreach (var result in results)
            {
                values.Add(result.average_value);
            }

            return values;
        }
        catch (Exception e)
        {
            Debug.LogError("Error opening database: " + e.Message);
            return new List<float>();
        }
    }

    public class YearAVG
    {
        public string Month { get; set; }
        public float average_value { get; set; }
    }




    private void ShowGraph(List<float> valueList, int maxVisibleValueAmount = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if (getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        if (maxVisibleValueAmount <= 0)
        {
            maxVisibleValueAmount = valueList.Count;
        }

        foreach (GameObject gameObject in gameObjectList)
        {
            Destroy(gameObject);
        }
        gameObjectList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float yMaximum = valueList[0];
        float yMinimum = valueList[0];

        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++)
        {

            float value = valueList[i];
            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        //yMaximum = yMaximum + (yDifference * 0.2f);
        //yMinimum = yMinimum - (yDifference * 0.2f);
        yMaximum = (float)Math.Round(yMaximum + (yDifference * 0.2f));
        yMinimum = (float)Math.Round(yMinimum - (yDifference * 0.2f));


        //yMinimum = 0f; 

        float xSize = graphWidth / (maxVisibleValueAmount + 1);

        int xIndex = 0;



        GameObject lastCircleGameObject = null;
        for (int i = Mathf.Max(valueList.Count - maxVisibleValueAmount, 0); i < valueList.Count; i++)
        {
            float xPosition = xSize + xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject dotConnectionGameObject = CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectList.Add(dotConnectionGameObject);
            }
            lastCircleGameObject = circleGameObject;

         
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -80f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            labelX.GetComponent<Text>().rectTransform.anchoredPosition -= new Vector2(20, 0);
            labelX.GetComponent<Text>().fontSize = 27;
            labelX.localEulerAngles = new Vector3(0, 0, 90f);
            gameObjectList.Add(labelX.gameObject);
            

            RectTransform dashX = Instantiate(dashTemplateY);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -3f);
            gameObjectList.Add(dashX.gameObject);
            //dashX.sizeDelta = new Vector2(dashX.sizeDelta.x, 2f);

            float lineLY = LowLevel;
            float lineHY = HighLevel;




            RectTransform lineL = Instantiate(lineLow);
            lineL.SetParent(graphContainer, false);
            lineL.gameObject.SetActive(true);
            lineL.anchoredPosition = new Vector2(0f, lineLY);
            lineL.sizeDelta = new Vector2(graphWidth, 1f);
            gameObjectList.Add(lineL.gameObject);

            RectTransform lineH = Instantiate(lineHigh);
            lineH.SetParent(graphContainer, false);
            lineH.gameObject.SetActive(true);
            lineH.anchoredPosition = new Vector2(0f, lineHY);
            lineH.sizeDelta = new Vector2(graphWidth, 1f);
            gameObjectList.Add(lineH.gameObject);

            Debug.Log("yMinimum: " + yMinimum);
            Debug.Log("yMaximum: " + yMaximum);
            Debug.Log("graphHeight: " + graphHeight);
            Debug.Log("lineH: " + lineHY);
            Debug.Log("lineL: " + lineLY);


            xIndex++;

        }

        int separatorCount = 10;
        for (int i = 0; i < separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.GetComponent<Text>().fontSize = 27;
            labelY.anchoredPosition = new Vector2(20f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (normalizedValue * (yMaximum - yMinimum)));
            gameObjectList.Add(labelY.gameObject);

            RectTransform dashY = Instantiate(dashTemplateX);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
            gameObjectList.Add(dashY.gameObject);
            //dashY.sizeDelta = new Vector2(3f, dashY.sizeDelta.x);
        }


        }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(RawImage));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<RawImage>().texture = circleTexture;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(17, 17);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }
    
    private GameObject CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(RawImage));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<RawImage>().color = new Color(0f, 0.1412f, 0.2078f, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        return gameObject;
    }
}
