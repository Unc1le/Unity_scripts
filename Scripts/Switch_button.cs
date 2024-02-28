using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch_button : MonoBehaviour
{
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;

    public GameObject buttonget;
    public GameObject buttonget1;
    public GameObject buttonget2;
    public GameObject buttonget3;
    public GameObject buttonget4;
    public GameObject buttonget5;
    public GameObject buttonget6;
    public GameObject buttonget7;
    public GameObject buttonget8;
    public GameObject buttonget9;


    public void HandleValueChanged(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log("Button");
                buttonget.gameObject.SetActive(true);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                button.gameObject.SetActive(true);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);
                break;

            case 1:
                Debug.Log("Button1");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(true);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(true);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 2:
                Debug.Log("Button2");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(true);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(true);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 3:
                Debug.Log("Button3");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(true);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(true);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 4:
                Debug.Log("Button4");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(true);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(true);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 5:
                Debug.Log("Button5");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(true);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(true);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 6:
                Debug.Log("Button6");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(true);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(true);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 7:
                Debug.Log("Button7");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(true);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(true);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(false);

                break;
            case 8:
                Debug.Log("Button8");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(true);
                button9.gameObject.SetActive(false);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(true);
                buttonget9.gameObject.SetActive(false);

                break;
            case 9:
                Debug.Log("Button9");
                button.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
                button4.gameObject.SetActive(false);
                button5.gameObject.SetActive(false);
                button6.gameObject.SetActive(false);
                button7.gameObject.SetActive(false);
                button8.gameObject.SetActive(false);
                button9.gameObject.SetActive(true);

                buttonget.gameObject.SetActive(false);
                buttonget1.gameObject.SetActive(false);
                buttonget2.gameObject.SetActive(false);
                buttonget3.gameObject.SetActive(false);
                buttonget4.gameObject.SetActive(false);
                buttonget5.gameObject.SetActive(false);
                buttonget6.gameObject.SetActive(false);
                buttonget7.gameObject.SetActive(false);
                buttonget8.gameObject.SetActive(false);
                buttonget9.gameObject.SetActive(true);

                break;
        }
    }


}
