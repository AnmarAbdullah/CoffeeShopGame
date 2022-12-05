using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelOne : Level
{
    [SerializeField] GameObject CustomerSatisfaction;
    [SerializeField] Slider PriceOfCappuccino;
    [SerializeField] Slider SpendingOnPromotion;
    [SerializeField] TextMeshProUGUI NumberOfDrinksSold;
    [SerializeField] TextMeshProUGUI Revenue;
    [SerializeField] TextMeshProUGUI ProfitMadeText;

    public override int Algorithm()
    {
        achieve.cur_SoldDrinks = (int)PriceOfCappuccino.value * reqs.CappuccinoPrice;
        achieve.cur_Revenues = (int)SpendingOnPromotion.value * reqs.SpendingOnPromotion;
        int result = achieve.cur_SoldDrinks * achieve.cur_Revenues;
        profitMade = result * 10;
        Debug.Log(profitMade);
        return profitMade;
    }

    public override void Results()
    {
        /*for (int i = 0; i < Random.Range(1,5); i++)
        {
            CustomerSatisfaction.transform.GetChild(i).gameObject.SetActive(true);
        }*/
        ProfitMadeText.text = $"Profit Made: {profitMade}";
        NumberOfDrinksSold.text = $"Number Of Drinks Sold: {achieve.cur_SoldDrinks}";
        Revenue.text = $"Revenue: {achieve.cur_Revenues}";
    }
}
