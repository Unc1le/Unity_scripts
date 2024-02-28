using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public ModBus_TCP_CLIENT tcp_data1;

    public int value_real; //“екущее значение
    public int value_summ; //—умматор
    public int number_req; //номер запроса TCP
    public int number_reg_real; //номер €чейки TCP в шлюзе
    public int number_reg_summ; //номер €чейки TCP в шлюзе      сумматор
    public Text text;
    public Text text2;
    public int highlvl;
    public int lowlvl;

    public void Start()
    {
        value_real = 0;
        
    }
    public void OnButtonClick()
    {
        value_real++;
        text.text = value_real.ToString();
       // Debug.Log(count);

        if (value_real < lowlvl || value_real > highlvl)
        {
            UpdateTextColor();
        }

    }


    public void UpdateTextColor()
    {
        if (value_real < lowlvl || value_real > highlvl)
        {
            text.color = Color.red;
        }
        
        else
        {
            text.color = Color.blue; 
        }
    }


    public void UpdateText()
    {

      //  value_real = tcp_data1.RX_REGS[number_req, number_reg_real];
      //  value_summ = tcp_data1.RX_REGS[number_req, number_reg_summ];

        //text.text = tcp_data1.RX_REGS[0,0].ToString();
        text.text = value_real.ToString();
        text2.text = value_summ.ToString();
        
    }
    public void SetTextValue(int newValue)
    {
        value_real = newValue;
        UpdateText();
        UpdateTextColor();
    }

    void Update()
    {



        UpdateTextColor();
        UpdateText();



    }
}
