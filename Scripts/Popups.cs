using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//скрипт отвечающий за окно отчетов во вкладке "Тренды"
public class Popups : MonoBehaviour
{
    public GameObject PopupPeriod;
    public GameObject PopupList;
    public GameObject ButtonListDay;
    public GameObject ButtonPeriod;
    public GameObject ButtonClosePopupList;
    public GameObject PanelDateInfo;
    public GameObject PanelWithButton;
    public GameObject PanelResetButton;
    public GameObject Tooltip;
    public GameObject TooltipButton;


    
    public void ShowAndHide()
    {
        StartCoroutine(ShowAndHideCoroutine());
    }

    IEnumerator ShowAndHideCoroutine()
    {
        Tooltip.SetActive(true);
        yield return new WaitForSeconds(6);
        Tooltip.SetActive(false);
    }
    public void PopupPeriodListOpen()
    {
        PopupPeriod.gameObject.SetActive(true);
        ButtonListDay.gameObject.SetActive(false);
        PanelWithButton.gameObject.SetActive(false);
        ButtonPeriod.gameObject.SetActive(false);
        PanelDateInfo.gameObject.SetActive(true);
        PanelResetButton.gameObject.SetActive(true);
        TooltipButton.gameObject.SetActive(true);
    }

    public void PopupListOpen()
    {
        PopupList.gameObject.SetActive(true);
        ButtonClosePopupList.gameObject.SetActive(true);
    }


    public void PopupPeriodListClose()
    {
        PopupPeriod.gameObject.SetActive(false);
        ButtonPeriod.gameObject.SetActive(true);
        ButtonListDay.gameObject.SetActive(true);
        PanelDateInfo.gameObject.SetActive(false);
        PanelResetButton.gameObject.SetActive(false);
        PanelWithButton.gameObject.SetActive(true);
        TooltipButton.gameObject.SetActive(false);



    }

    public void PopupListClose()
    {
        PopupList.gameObject.SetActive(false);
        ButtonClosePopupList.gameObject.SetActive(false);

    }

}