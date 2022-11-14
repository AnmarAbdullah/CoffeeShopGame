using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{

    public int TargetMoney;

    public GameObject[] News;
    public GameObject FailSucUI;
    public GameObject DecisionMaking;
    public TextMeshProUGUI SucFail;
    public int currentYear = 1;
    public int CollectedMoney;
    public Button startYear;
    public Button nextYear;
    public Button Continue;
    public Slider Cuppuccino;
    public Slider SpendingOnPromotion;
    public Slider SalaryEmployee;
    public Slider Trainingspending;

    bool yearEnded;

    void Start()
    {
        startYear.onClick.AddListener(() =>
        {
            CollectedMoney = algorithm((int)Cuppuccino.value, (int)SpendingOnPromotion.value, (int)SalaryEmployee.value, (int)Trainingspending.value);
            if (CollectedMoney >= TargetMoney)
            {
                Success();
            }
            if (CollectedMoney < TargetMoney)
            {
                Failed();
            }
        });
        
        nextYear.onClick.AddListener(() =>
        {
            currentYear++;
            News[currentYear - 1].gameObject.SetActive(true);
            Continue.gameObject.SetActive(true);
            FailSucUI.gameObject.SetActive(false);
        });

        Continue.onClick.AddListener(() =>
        {
            News[currentYear - 1].gameObject.SetActive(false);
            DecisionMaking.gameObject.SetActive(true);
            Continue.gameObject.SetActive(false);
        });
    }

    void Update()
    {

    }

    public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
        return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }

    public void Success()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Succeeded"; 
    }

    public void Failed()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Failed";
    }

    public void nextLevel()
    {

    }
}
