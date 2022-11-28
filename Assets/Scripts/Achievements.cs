using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Achievements : ScriptableObject
{
    public int Level;

    [Header("Base Stats")]
    public int SoldDrinks;
    public int Revenues;
    public int Costs;
    public int Profit;

    [Header("Current Stats")]
    public int cur_SoldDrinks;
    public int cur_Revenues;
    public int cur_Costs;
    public int cur_Profit;
}
