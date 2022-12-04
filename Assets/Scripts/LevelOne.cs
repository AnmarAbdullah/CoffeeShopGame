using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOne : Level
{
    [SerializeField] Slider PriceOfCappuccino;
    [SerializeField] Slider SpendingOnPromotion;

    public override int Algorithm()
    {
        achieve.cur_SoldDrinks = (int)PriceOfCappuccino.value * reqs.CappuccinoPrice;
        achieve.cur_Revenues = (int)SpendingOnPromotion.value * reqs.SpendingOnPromotion;
        int result = achieve.SoldDrinks* achieve.cur_Revenues;
        Debug.Log(result);
        return result;
    }
}
