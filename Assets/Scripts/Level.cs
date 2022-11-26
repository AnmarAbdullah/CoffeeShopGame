using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[Serielizable]
public class Level : MonoBehaviour
{
    [Header("General UI")]
    [SerializeField] GameObject[] News;
    [SerializeField] GameObject FailSucUI;
    [SerializeField] GameObject[] customerStars;
    [SerializeField] GameObject[] employeeStars;
    [SerializeField] GameObject DecisionMaking;
    [SerializeField] GameObject NextLevel;

    [SerializeField] TextMeshProUGUI SucFail;
    [SerializeField] int currentYear = 1;
    [SerializeField] float CollectedMoney;
    
    [Header("Buttons")]
    [SerializeField] Button startYear;
    [SerializeField] Button nextYear;
    [SerializeField] Button Continue;
    [SerializeField] Button backButton;
    [SerializeField] Button nextLevel;
    
    [Header("Sliders")]
    [SerializeField] Slider[] sliders;

    [SerializeField] int TargetMoney;
    [SerializeField] int currentProfit;
    [SerializeField] int totalProfit;
    int Successes;
    int index;
    int random;

    void Start()
    {
        startYear.onClick.AddListener(() =>
        {
            //CollectedMoney = algorithm((int)Cuppuccino.value, (int)SpendingOnPromotion.value, (int)SalaryEmployee.value, (int)Trainingspending.value);
            currentProfit = (int)algorithm(sliders);
            totalProfit += currentProfit;
            int starRate = Random.Range(0, 5);
            Debug.Log(starRate);
            for (int i = 0; i < starRate; i++)
            {
                employeeStars[i].SetActive(true);
                customerStars[i].SetActive(true);
            }
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
            random = Random.Range(1, News.Length);
            if (currentYear > 5)
            {
                News[random].gameObject.SetActive(true);
            }
            else News[currentYear - 1].gameObject.SetActive(true);
            Continue.gameObject.SetActive(true);
            FailSucUI.gameObject.SetActive(false);
            if (Successes >= 3)
            {
                NextLevel.gameObject.SetActive(true) ;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        });

        Continue.onClick.AddListener(() =>
        {
            if(currentYear > 5)
            {
                News[random].gameObject.SetActive(false);
            }
            else News[currentYear - 1].gameObject.SetActive(false);
            DecisionMaking.gameObject.SetActive(true);
            Continue.gameObject.SetActive(false);
        });

        backButton.onClick.AddListener(() =>
        {
            News[currentYear - 1].gameObject.SetActive(true);
            Continue.gameObject.SetActive(true);
        });

        nextLevel.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

    }

    void Update()
    {

    }

    public float algorithm(Slider[] test)
    {
        for (int i = 0; i < test.Length; i++)
        {    
            float current = test[i].value;
            if (i ==0)
            {
                float result = current * test[i + 1].value;
                currentProfit = (int)result;
            }
            if(i > 0)
            {
                //float result = current * profitMade;
                currentProfit += (int)current * currentProfit;
            }
            /*else
            {
                profitMade += (int)current * (int)test[i].value;
            }*/

            //In here I will be making required values for each year..and then i will check wih if statement how far they are from the required numbers
            //After that it will determine if they are too less or too high on the numbers, it means its bad and will affect the results badly..
            //If they are close enough to the numbers required, then it will have better results.
        }
        return currentProfit / 2;
    }
    /*public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
        return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }*/

    public void Success()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Profit Made: " + CollectedMoney;
        Successes += 1;
    }

    public void Failed()
    {
        FailSucUI.gameObject.SetActive(true);
        SucFail.text = "Profit Made: " + CollectedMoney;
        Successes = 0;
    }
}