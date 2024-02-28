using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Этот скрипт отвечает за цвет значений во вкладке "Расходы"


public class color_value : MonoBehaviour
{
    public float value;
    public Text text_obj;


    public void SetColor()
    {
        Text textform = this.GetComponent<Text>();


        if (value < 50)
        {
            Debug.Log("Error");
            GetComponent<Text>().text = "Error";

        }
        else if (value > 70)
        {
            Debug.Log("Error");
            GetComponent<Text>().text = "Error";

        }
        else
        {
            Debug.Log("Norm");
            GetComponent<Text>().text = "Norm";

        }
    }


    void Start()
    {


    }

    void Update()
    {
        SetColor();
    }

}
