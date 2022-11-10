using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Logic : MonoBehaviour
{
    float requiredThreshold;
    float currentMoney;

    List<string> names = new List<string>();
    List<int> requiredValues = new List<int>();
    enum Years
    {
        year1,
        year2,
        year3,
        year4,
        year5
    }
    Years CurrentYear;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentYear)
        {
            case Years.year1:
                names[0] = "Average Salary Per Employee";
                requiredValues[0] = 30;
                break;
        }
    }
}
