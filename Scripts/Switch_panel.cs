using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch_panel : MonoBehaviour
{
    public GameObject table;
    public GameObject filter;
    public GameObject knopkalog;
    public GameObject knopkaexit;
    public GameObject panelka;

    public void Panel1()
    {
        table.gameObject.SetActive(true);
        filter.gameObject.SetActive(false);
        
    }

    public void Panel2()
    {
        table.gameObject.SetActive(false);
        filter.gameObject.SetActive(true);
      
    }

    public void LogsTable()
    {
        
        panelka.gameObject.SetActive(true);
        knopkaexit.gameObject.SetActive(true);

    }
    public void CloseTable()
    {
        knopkaexit.gameObject.SetActive(false);
        panelka.gameObject.SetActive(false);

    }


}
