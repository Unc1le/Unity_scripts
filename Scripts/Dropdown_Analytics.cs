using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Этот код отвечает за переключение панелей дропдауна во вкладке "Аналитика"
public class Dropdown_Anal : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    public GameObject block6;



    public void HandleValueChanged(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log("Block1");
                block1.gameObject.SetActive(true);
                block2.gameObject.SetActive(false);
                block3.gameObject.SetActive(false);
                block4.gameObject.SetActive(false);
                block5.gameObject.SetActive(false);
                block6.gameObject.SetActive(false);
                break;

            case 1:
                Debug.Log("Block2");
                block1.gameObject.SetActive(false);
                block2.gameObject.SetActive(true);
                block3.gameObject.SetActive(false);
                block4.gameObject.SetActive(false);
                block5.gameObject.SetActive(false);
                block6.gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log("Block3");
                block1.gameObject.SetActive(false);
                block2.gameObject.SetActive(false);
                block3.gameObject.SetActive(true);
                block4.gameObject.SetActive(false);
                block5.gameObject.SetActive(false);
                block6.gameObject.SetActive(false);
                break;
            case 3:
                Debug.Log("Block4");
                block1.gameObject.SetActive(false);
                block2.gameObject.SetActive(false);
                block3.gameObject.SetActive(false);
                block4.gameObject.SetActive(true);
                block5.gameObject.SetActive(false);
                block6.gameObject.SetActive(false);
                break;
            case 4:
                Debug.Log("Block5");
                block1.gameObject.SetActive(false);
                block2.gameObject.SetActive(false);
                block3.gameObject.SetActive(false);
                block4.gameObject.SetActive(false);
                block5.gameObject.SetActive(true);
                block6.gameObject.SetActive(false);
                break;
            case 5:
                Debug.Log("Block6");
                block1.gameObject.SetActive(false);
                block2.gameObject.SetActive(false);
                block3.gameObject.SetActive(false);
                block4.gameObject.SetActive(false);
                block5.gameObject.SetActive(false);
                block6.gameObject.SetActive(true);
                break;
        }
    }


}
