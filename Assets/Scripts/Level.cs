using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [Header("General UI")]
    public GameObject[] News;
    public GameObject FailSucUI;
    public GameObject DecisionMaking;

    public TextMeshProUGUI SucFail;
    public int currentYear = 1;
    public float CollectedMoney;
    
    [Header("Buttons")]
    public Button startYear;
    public Button nextYear;
    public Button Continue;
    
    [Header("Sliders")]
    public Slider[] sliders;

    int Successes;
    int index;
    public int TargetMoney;
    int random;

    void Start()
    {
        startYear.onClick.AddListener(() =>
        {
            //CollectedMoney = algorithm((int)Cuppuccino.value, (int)SpendingOnPromotion.value, (int)SalaryEmployee.value, (int)Trainingspending.value);
            CollectedMoney = algorithm(sliders);
            Debug.Log(CollectedMoney);
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
            random = Random.Range(0, News.Length);
            if (currentYear > 6)
            {
                News[random].gameObject.SetActive(true);
            }
            else News[currentYear - 1].gameObject.SetActive(true);
            Continue.gameObject.SetActive(true);
            FailSucUI.gameObject.SetActive(false);
            if (Successes >= 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        });

        Continue.onClick.AddListener(() =>
        {
            if(currentYear > 6)
            {
                News[random].gameObject.SetActive(false);
            }
            else News[currentYear - 1].gameObject.SetActive(false);
            DecisionMaking.gameObject.SetActive(true);
            Continue.gameObject.SetActive(false);
        });
    }

    void Update()
    {

    }

    public float algorithm(Slider[] test)
    {
        float result = 0;
        for (int i = 0; i < test.Length; i++)
        {    
            float current = test[i].value;
            if (i < test.Length - 1)
            {
                float currentResult = current * test[i + 1].value;
                result += currentResult;
            }
            else
            {
                result = current * test[i].value;
            }
        }
        return result * 10;
    }
    /*public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
        return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }*/

    public void Success()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Succeeded";
        Successes += 1;
    }

    public void Failed()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Failed";
        Successes = 0;
    }
}