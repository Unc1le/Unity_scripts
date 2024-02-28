using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FlowmeterService 
{
    DB dB;

    public FlowmeterService()
    {
        dB = new DB();
    }

    public void CreateMultipleFlowmeterTablesDB(int numberOfTables)
    {
        for (int i = 1; i <= numberOfTables; i++)
        {
            var tableName = $"Flowmeter_{i.ToString("D2")}";
            var tableExists = dB.GetConnection().GetTableInfo(tableName).Count;

            if (tableExists > 0)
            {
                continue;
            }

            var query = $"CREATE TABLE {tableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT, Instant_consumption REAL, Total_consumption REAL, Time TEXT, Day INTEGER, Month INTEGER, Year INTEGER, Date TEXT)";
            dB.GetConnection().Execute(query);
        }
    }

    public int AddFlowmeter(Flowmeter_01 flowmeter1)
    {
        return dB.GetConnection().Insert(flowmeter1);
    }
    public int AddFlowmeter(Flowmeter_02 flowmeter2)
    {
        return dB.GetConnection().Insert(flowmeter2);
    }
    public int AddFlowmeter(Flowmeter_03 flowmeter3)
    {
        return dB.GetConnection().Insert(flowmeter3);
    }
    public int AddFlowmeter(Flowmeter_04 flowmeter4)
    {
        return dB.GetConnection().Insert(flowmeter4);
    }
    public int AddFlowmeter(Flowmeter_05 flowmeter5)
    {
        return dB.GetConnection().Insert(flowmeter5);
    }
    public int AddFlowmeter(Flowmeter_06 flowmeter6)
    {
        return dB.GetConnection().Insert(flowmeter6);
    }
    public int AddFlowmeter(Flowmeter_07 flowmeter7)
    {
        return dB.GetConnection().Insert(flowmeter7);
    }
    public int AddFlowmeter(Flowmeter_08 flowmeter8)
    {
        return dB.GetConnection().Insert(flowmeter8);
    }
    public int AddFlowmeter(Flowmeter_09 flowmeter9)
    {
        return dB.GetConnection().Insert(flowmeter9);
    }
    public int AddFlowmeter(Flowmeter_10 flowmeter10)
    {
        return dB.GetConnection().Insert(flowmeter10);
    }
    public int AddFlowmeter(Flowmeter_11 flowmeter11)
    {
        return dB.GetConnection().Insert(flowmeter11);
    }
    public int AddFlowmeter(Flowmeter_12 flowmeter12)
    {
        return dB.GetConnection().Insert(flowmeter12);
    }
    public int AddFlowmeter(Flowmeter_13 flowmeter13)
    {
        return dB.GetConnection().Insert(flowmeter13);
    }
    public int AddFlowmeter(Flowmeter_14 flowmeter14)
    {
        return dB.GetConnection().Insert(flowmeter14);
    }
    public int AddFlowmeter(Flowmeter_15 flowmeter15)
    {
        return dB.GetConnection().Insert(flowmeter15);
    }
    public int AddFlowmeter(Flowmeter_16 flowmeter16)
    {
        return dB.GetConnection().Insert(flowmeter16);
    }
    public int AddFlowmeter(Flowmeter_17 flowmeter17)
    {
        return dB.GetConnection().Insert(flowmeter17);
    }
    public int AddFlowmeter(Flowmeter_18 flowmeter18)
    {
        return dB.GetConnection().Insert(flowmeter18);
    }
    public int AddFlowmeter(Flowmeter_19 flowmeter19)
    {
        return dB.GetConnection().Insert(flowmeter19);
    }
    public int AddFlowmeter(Flowmeter_20 flowmeter20)
    {
        return dB.GetConnection().Insert(flowmeter20);
    }
    public int AddFlowmeter(Flowmeter_21 flowmeter21)
    {
        return dB.GetConnection().Insert(flowmeter21);
    }
    public int AddFlowmeter(Flowmeter_22 flowmeter22)
    {
        return dB.GetConnection().Insert(flowmeter22);
    }
    public int AddFlowmeter(Flowmeter_23 flowmeter23)
    {
        return dB.GetConnection().Insert(flowmeter23);
    }
    public int AddFlowmeter(Flowmeter_24 flowmeter24)
    {
        return dB.GetConnection().Insert(flowmeter24);
    }
    public int AddFlowmeter(Flowmeter_25 flowmeter25)
    {
        return dB.GetConnection().Insert(flowmeter25);
    }
    public int AddFlowmeter(Flowmeter_26 flowmeter26)
    {
        return dB.GetConnection().Insert(flowmeter26);
    }
    public int AddFlowmeter(Flowmeter_27 flowmeter27)
    {
        return dB.GetConnection().Insert(flowmeter27);
    }
    public int AddFlowmeter(Flowmeter_28 flowmeter28)
    {
        return dB.GetConnection().Insert(flowmeter28);
    }
    public int AddFlowmeter(Flowmeter_29 flowmeter29)
    {
        return dB.GetConnection().Insert(flowmeter29);
    }
    public int AddFlowmeter(Flowmeter_30 flowmeter30)
    {
        return dB.GetConnection().Insert(flowmeter30);
    }
    public int AddFlowmeter(Flowmeter_31 flowmeter31)
    {
        return dB.GetConnection().Insert(flowmeter31);
    }
    public int AddFlowmeter(Flowmeter_32 flowmeter32)
    {
        return dB.GetConnection().Insert(flowmeter32);
    }
    public int AddFlowmeter(Flowmeter_33 flowmeter33)
    {
        return dB.GetConnection().Insert(flowmeter33);
    }
    public int AddFlowmeter(Flowmeter_34 flowmeter34)
    {
        return dB.GetConnection().Insert(flowmeter34);
    }
    public int AddFlowmeter(Flowmeter_35 flowmeter35)
    {
        return dB.GetConnection().Insert(flowmeter35);
    }
    public int AddFlowmeter(Flowmeter_36 flowmeter36)
    {
        return dB.GetConnection().Insert(flowmeter36);
    }
    public int AddFlowmeter(Flowmeter_37 flowmeter37)
    {
        return dB.GetConnection().Insert(flowmeter37);
    }
    public int AddFlowmeter(Flowmeter_38 flowmeter38)
    {
        return dB.GetConnection().Insert(flowmeter38);
    }
    public int AddFlowmeter(Flowmeter_39 flowmeter39)
    {
        return dB.GetConnection().Insert(flowmeter39);
    }
    public int AddFlowmeter(Flowmeter_40 flowmeter40)
    {
        return dB.GetConnection().Insert(flowmeter40);
    }
    public int AddFlowmeter(Flowmeter_41 flowmeter41)
    {
        return dB.GetConnection().Insert(flowmeter41);
    }
    public int AddFlowmeter(Flowmeter_42 flowmeter42)
    {
        return dB.GetConnection().Insert(flowmeter42);
    }
    public int AddFlowmeter(Flowmeter_43 flowmeter43)
    {
        return dB.GetConnection().Insert(flowmeter43);
    }
    public int AddFlowmeter(Flowmeter_44 flowmeter44)
    {
        return dB.GetConnection().Insert(flowmeter44);
    }
    public int AddFlowmeter(Flowmeter_45 flowmeter45)
    {
        return dB.GetConnection().Insert(flowmeter45);
    }
    public int AddFlowmeter(Flowmeter_46 flowmeter46)
    {
        return dB.GetConnection().Insert(flowmeter46);
    }
    public int AddFlowmeter(Flowmeter_47 flowmeter47)
    {
        return dB.GetConnection().Insert(flowmeter47);
    }
    public int AddFlowmeter(Flowmeter_48 flowmeter48)
    {
        return dB.GetConnection().Insert(flowmeter48);
    }
    public int AddFlowmeter(Flowmeter_49 flowmeter49)
    {
        return dB.GetConnection().Insert(flowmeter49);
    }
    public int AddFlowmeter(Flowmeter_50 flowmeter50)
    {
        return dB.GetConnection().Insert(flowmeter50);
    }
    public int AddFlowmeter(Flowmeter_51 flowmeter51)
    {
        return dB.GetConnection().Insert(flowmeter51);
    }
    public int AddFlowmeter(Flowmeter_52 flowmeter52)
    {
        return dB.GetConnection().Insert(flowmeter52);
    }
    public int AddFlowmeter(Flowmeter_53 flowmeter53)
    {
        return dB.GetConnection().Insert(flowmeter53);
    }
    public int AddFlowmeter(Flowmeter_54 flowmeter54)
    {
        return dB.GetConnection().Insert(flowmeter54);
    }
    public int AddFlowmeter(Flowmeter_55 flowmeter55)
    {
        return dB.GetConnection().Insert(flowmeter55);
    }
    public int AddFlowmeter(Flowmeter_56 flowmeter56)
    {
        return dB.GetConnection().Insert(flowmeter56);
    }
    public int AddFlowmeter(Flowmeter_57 flowmeter57)
    {
        return dB.GetConnection().Insert(flowmeter57);
    }
    public int AddFlowmeter(Flowmeter_58 flowmeter58)
    {
        return dB.GetConnection().Insert(flowmeter58);
    }
    public int AddFlowmeter(Flowmeter_59 flowmeter59)
    {
        return dB.GetConnection().Insert(flowmeter59);
    }
    public int AddFlowmeter(Flowmeter_60 flowmeter60)
    {
        return dB.GetConnection().Insert(flowmeter60);
    }






}
