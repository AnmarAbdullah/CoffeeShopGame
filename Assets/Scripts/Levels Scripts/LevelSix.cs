using UnityEngine;
using UnityEngine.UI;

public class LevelSix : Level
{
    [Space(5)]
    [Header("Decisions Of This Level")]
    [SerializeField] Slider PriceOfCappuccino;
    [SerializeField] Slider SpendingOnPromotion;
    [SerializeField] Slider SalaryOfEmployee;
    [SerializeField] Slider SpendingOnTraining;
    [SerializeField] Toggle ServeFairTradeCoffee;
    [SerializeField] Toggle ServeOrganicCoffee;
    [SerializeField] Toggle ServeFood;

    public override int Algorithm()
    {
        achieve.cur_SoldDrinks = (int)PriceOfCappuccino.value * reqs.CappuccinoPrice;
        achieve.cur_Revenues = (int)SpendingOnPromotion.value * reqs.SpendingOnPromotion;
        achieve.cur_Costs = (int)SalaryOfEmployee.value * reqs.EmployeesSalary;
        achieve.cur_Revenues = (int)SpendingOnTraining.value * reqs.SpendingOnPromotion;
        int result = (int)PriceOfCappuccino.value * (int)SpendingOnPromotion.value
            * (int)SalaryOfEmployee.value * (int)SpendingOnPromotion.value;
        Debug.Log(result);
        if (ServeFairTradeCoffee.isOn != reqs.ServeFairTradeCoffee)
        {
            result /= 2;
        }
        profitMade = result * 10;
        return profitMade; //talking to someone
    }
}
