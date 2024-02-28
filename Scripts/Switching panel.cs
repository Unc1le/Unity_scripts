using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switching_panel : MonoBehaviour
{
    public GameObject expenses;
    public GameObject balance;
    public GameObject trends;
    public GameObject analitic;

    public void Panel1()
    {
        expenses.gameObject.SetActive(true);
        balance.gameObject.SetActive(false);
        trends.gameObject.SetActive(false);
        analitic.gameObject.SetActive(false);

    }
    
    public void Panel2()
    {
        expenses.gameObject.SetActive(false);
        balance.gameObject.SetActive(true);
        trends.gameObject.SetActive(false);
        analitic.gameObject.SetActive(false);
    }

    public void Panel3()
    {
        expenses.gameObject.SetActive(false);
        balance.gameObject.SetActive(false);
        trends.gameObject.SetActive(true);
        analitic.gameObject.SetActive(false);

    }

    public void Panel4()
    {
        expenses.gameObject.SetActive(false);
        balance.gameObject.SetActive(false);
        trends.gameObject.SetActive(false);
        analitic.gameObject.SetActive(true);

    }


   
}
