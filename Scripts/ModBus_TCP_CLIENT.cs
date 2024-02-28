using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
//using static System.Net.Sockets.TcpClient;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ModBus_TCP_CLIENT : MonoBehaviour
{

    const int MAX_REQ = 100;

    public string state_TCP = "NONE_CONNECT";
    public byte[] data_rx = new byte[512];
    public byte[] data_tx = new byte[512];
    int port = 502;

    public ushort[,] TX_REGS = new ushort[MAX_REQ, 125];
    public byte[,] TX_BYTES = new byte[MAX_REQ, 125];
    public ushort[,] RX_REGS = new ushort[MAX_REQ, 125];
    public byte[,] RX_BYTES = new byte[MAX_REQ, 125];

    public int ACTIVE_REQ = 0; //текущий запрос, индекс из массива активных запросов
    public int NUMBER_REQ = 0; //текущий запрос, пор€дковое значение
    public int tx_count;


    TcpClient client;
    NetworkStream stream;

    public float timer = 0.0f;

    public int COUNT_ENABLE_REQ = 0;// оличество вкюченных запросов
    public int[] ARRAY_ACTIVE_REQ = new int[MAX_REQ]; //ћассив с индексами активных запросов

    [System.Serializable]
    public struct MODBUS_TCP_REQ
    {
        public string IP;
        public byte FC;
        public ushort ADR_FIRST_REG;
        public ushort NUMBER_REG;
        public int SET_ATTEMPT;
        public int SET_TIMEOUT;
        public string STATE;
        public bool CONNECT;
        public bool ENABLE;
        public int LEN_MESSAGE_TX;
        public int LEN_MESSAGE_RX;
    };

    public MODBUS_TCP_REQ[] ARRAY_REQ = new MODBUS_TCP_REQ[MAX_REQ];


    void Start()
    {
        InvokeRepeating("TCP_Client_Active", 2, 0.250f); //0.1

      //  InvokeRepeating("TIMER_100MS", 1, 0.1f); //0.1
    }

    void Create_ModbusTCP_Client()
    {
        client = new TcpClient();
        return;
    }
    void Close_ModbusTCP_Client()
    {
        stream.Close();
        client.Close();
        ARRAY_REQ[ACTIVE_REQ].STATE = "NONE_CONNECT";
        state_TCP = "NONE_CONNECT";
        return;
    }
    void Send_ModbusTCP_Client()
    {
        try
        {
            stream.Write(data_tx, 0, ARRAY_REQ[ACTIVE_REQ].LEN_MESSAGE_TX);
            ARRAY_REQ[ACTIVE_REQ].STATE = "SENT";
            state_TCP = "SENT";
        }
        catch
        {
            ARRAY_REQ[ACTIVE_REQ].STATE = "ERROR_NOT_SENT";
            state_TCP = "ERROR";
        }
    }
    void Parsing_Message_ModbusTCP_Client()
    {
        if (data_rx[7] != ARRAY_REQ[ACTIVE_REQ].FC) 
        {
            return;
        }


        if (data_rx[8] != (ARRAY_REQ[ACTIVE_REQ].NUMBER_REG * 2))
        {
            return;
        }

        int i = 0;
        while(i < ARRAY_REQ[ACTIVE_REQ].NUMBER_REG)
        {

            RX_REGS[ACTIVE_REQ,i] = (ushort)((data_rx[9 + i * 2] << 8) + data_rx[10 + i * 2]);
            i++;
        }



    }
    void Recieve_ModbusTCP_Client()
    {
        try
        {
            int len_rx = data_rx.Length;
            ARRAY_REQ[ACTIVE_REQ].LEN_MESSAGE_RX = stream.Read(data_rx, 0, len_rx);
            state_TCP = "WAIT RECIEVE";

            while (stream.DataAvailable == true)
            {

            }
            state_TCP = "ACCEPTED";
            ARRAY_REQ[ACTIVE_REQ].STATE = "ACCEPTED";
            Parsing_Message_ModbusTCP_Client();
        }
        catch
        {
            ARRAY_REQ[ACTIVE_REQ].STATE = "ERROR_NOT_RECIEVE";
            state_TCP = "ERROR";
        }
    }
    public async void Open_ModbusTCP_Client(string IP)
    {
        //try { await client.ConnectAsync(IP, 502); }
        try
        {
            var state_connect = client.BeginConnect(IP, 502, null, null);
            var success = state_connect.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.005f));

            if (!success)
            {
                ARRAY_REQ[ACTIVE_REQ].STATE = "ERROR_NOT_CONNECT";
                state_TCP = "ERROR";
                return;
            }
        }
        catch
        {
            ARRAY_REQ[ACTIVE_REQ].STATE = "ERROR_NOT_CONNECT";
            state_TCP = "ERROR";
            return;
        }

        if (client.Connected)
        {
            state_TCP = "CONNECT";
            ARRAY_REQ[ACTIVE_REQ].STATE = "CONNECT";
            client.SendTimeout = 100;
            client.ReceiveTimeout = 100;
            stream = client.GetStream();
        }

        return;
    }
    void Create_Message_ModbusTCP_Client()
    {

        if (ARRAY_REQ[ACTIVE_REQ].FC == 0x01 || ARRAY_REQ[ACTIVE_REQ].FC == 0x02 || ARRAY_REQ[ACTIVE_REQ].FC == 0x03 || ARRAY_REQ[ACTIVE_REQ].FC == 0x04)
        {
            data_tx[0] = 0;
            data_tx[1] = 1;
            data_tx[2] = 0;
            data_tx[3] = 0;
            data_tx[4] = 0;
            data_tx[5] = 6;
            data_tx[6] = 1;
            data_tx[7] = ARRAY_REQ[ACTIVE_REQ].FC;
            data_tx[8] = (byte)(ARRAY_REQ[ACTIVE_REQ].ADR_FIRST_REG >> 8);
            data_tx[9] = (byte)(ARRAY_REQ[ACTIVE_REQ].ADR_FIRST_REG);
            data_tx[10] = 0;
            data_tx[11] = (byte)(ARRAY_REQ[ACTIVE_REQ].NUMBER_REG);
            ARRAY_REQ[ACTIVE_REQ].LEN_MESSAGE_TX = 12;
        }





    }




    public async void TCP_Client_Active()
    {

        timer = timer + 0.250f;

        COUNT_ENABLE_REQ = CHECK_ENABLE_REQ();

        if (COUNT_ENABLE_REQ == 0)
        {
            return;
        }

        if (NUMBER_REQ >= COUNT_ENABLE_REQ)
        {
            NUMBER_REQ = 0;
        }
        ACTIVE_REQ = ARRAY_ACTIVE_REQ[NUMBER_REQ];



        if(state_TCP == "NONE_CONNECT") 
        {
            Create_ModbusTCP_Client();
            Open_ModbusTCP_Client(ARRAY_REQ[ACTIVE_REQ].IP);
        }

        if(state_TCP == "CONNECT")
        {

            Create_Message_ModbusTCP_Client();
            Send_ModbusTCP_Client();
        }

        if (state_TCP == "SENT")
        {
            Recieve_ModbusTCP_Client();
        }

        if (state_TCP == "ACCEPTED")
        {
            Close_ModbusTCP_Client();
            ARRAY_REQ[ACTIVE_REQ].CONNECT = true;
            NUMBER_REQ++;
        }

        if(state_TCP == "ERROR") 
        {
            ARRAY_REQ[ACTIVE_REQ].CONNECT = false;
            state_TCP = "NONE_CONNECT";
            if(client != null) { client.Close(); }
            NUMBER_REQ++;
        }




        return;
    }

   
    public async void TIMER_100MS()
    {


    }


    int CHECK_ENABLE_REQ() 
    {
        int i = 0;
        int value = 0;
        Array.Clear(ARRAY_ACTIVE_REQ, 0, MAX_REQ);

        while (i < MAX_REQ) 
        {
            if(ARRAY_REQ[i].ENABLE == true)
            {       
                ARRAY_ACTIVE_REQ[value] = i;
                value++;
            }
            i++;
        }

        return value;
    }



















}    

