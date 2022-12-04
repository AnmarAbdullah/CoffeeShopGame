using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFour : Level
{
    [SerializeField] Slider PriceOfCappuccino;
    [SerializeField] Slider SpendingOnPromotion;
    [SerializeField] Slider SalaryOfEmployee;
    [SerializeField] Slider SpendingOnTraining;
    [SerializeField] Toggle ServeFairTradeCoffee;
    [SerializeField] TextMeshProUGUI NumberOfDrinksSold;
    [SerializeField] TextMeshProUGUI Revenue;
    [SerializeField] TextMeshProUGUI Cost;
    [SerializeField] TextMeshProUGUI ProfitMadeText;

    public override int Algorithm()
    {
        achieve.cur_SoldDrinks = (int)PriceOfCappuccino.value * reqs.CappuccinoPrice;
        achieve.cur_Revenues = (int)SpendingOnPromotion.value * reqs.SpendingOnPromotion;
        achieve.cur_Costs = (int)SalaryOfEmployee.value * reqs.EmployeesSalary;
        achieve.cur_Revenues = (int)SpendingOnTraining.value * reqs.SpendingOnPromotion;
        int result = (int)PriceOfCappuccino.value * (int)SpendingOnPromotion.value
            * (int)SalaryOfEmployee.value * (int)SpendingOnPromotion.value;
        Debug.Log(result);
        if (ServeFairTradeCoffee.isOn != reqs.ServeFairTradeCoffee) {
            result /= 2;
        }
        profitMade = result * 10;
        return profitMade; //talking to someone
    }
    public override void Results()
    {
        ProfitMadeText.text = $"Profit Made: {profitMade}";
        NumberOfDrinksSold.text = $"Number Of Drinks Sold: {achieve.cur_SoldDrinks}";
        Revenue.text = $"Revenue: {achieve.cur_Revenues}";
        Cost.text = $"Cost: {achieve.cur_Costs}";
    }
}
