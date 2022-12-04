using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirements : MonoBehaviour
{
    [Header("All Levels")]
    public int TargetProfit;
    public int CappuccinoPrice;
    public int SpendingOnPromotion;
    [Header("Level 3 and Onwards")]
    public int EmployeesSalary;
    public int TrainingSpending;
    [Header("Level 4 and Onwards")]
    public bool ServeFairTradeCoffee;
    [Header("Level 5 and Onwards")]
    public bool ServeOrganicCoffee;
    public bool RoastingMachine;
    public int HireOrFireStaff;
    public bool IncludeFoodItems;
    public bool OpenInEvenings;
}
