using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int profitMade;
    public Requirements reqs;
    public Achievements achieve;

    [SerializeField] GameObject CustomerSatisfaction;
    [SerializeField] GameObject EmployeeSatisfaction;
    [SerializeField] TextMeshProUGUI NumberOfDrinksSold;
    [SerializeField] TextMeshProUGUI Revenue;
    [SerializeField] TextMeshProUGUI ProfitMadeText;
    [SerializeField] TextMeshProUGUI Cost;
    public virtual int Algorithm()
    {
        return 0;
    }
    public virtual void Results()
    {
      // this is a fake algorithm for now used in every level
      // to make a new algorithm for the results...override this function in the classes inheriting from this one.
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            CustomerSatisfaction.transform.GetChild(i).gameObject.SetActive(true);
            if (EmployeeSatisfaction != null)
            {
                EmployeeSatisfaction.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        ProfitMadeText.text = $"Profit Made: {profitMade}";
        NumberOfDrinksSold.text = $"Number Of Drinks Sold: {achieve.cur_SoldDrinks}";
        Revenue.text = $"Revenue: {achieve.cur_Revenues}";
        Cost.text = $"Cost: {achieve.cur_Costs}";
    }
}
