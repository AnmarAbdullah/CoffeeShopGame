using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelThree : Level
{
    [SerializeField] Slider PriceOfCappuccino;
    [SerializeField] Slider SpendingOnPromotion;
    [SerializeField] Slider SalaryOfEmployee;
    [SerializeField] Slider SpendingOnTraining;

    public override int Algorithm()
    {
        PriceOfCappuccino.value = PriceOfCappuccino.value * reqs.CappuccinoPrice;
        SpendingOnPromotion.value = SpendingOnPromotion.value * reqs.SpendingOnPromotion;
        int result = (int)PriceOfCappuccino.value * (int)SpendingOnPromotion.value;
        Debug.Log(result);
        return result * 10;
    }
}
