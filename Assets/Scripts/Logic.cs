using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[Serielizable]
public class Logic : MonoBehaviour
{
    [Header("General UI")]
    [SerializeField] GameObject[] News;
    [SerializeField] GameObject ResultsUI;
    [SerializeField] GameObject[] customerStars;
    [SerializeField] GameObject[] employeeStars;
    [SerializeField] GameObject DecisionMaking;
    [SerializeField] GameObject NextLevel;

    [SerializeField] TextMeshProUGUI ProfitText;
    [SerializeField] int currentYear = 1;
    [SerializeField] float CollectedMoney;
    
    [Header("Buttons")]
    [SerializeField] Button startYear;
    [SerializeField] Button nextYear;
    [SerializeField] Button Continue;
    [SerializeField] Button backButton;
    [SerializeField] Button nextLevel;
    
    [Header("Sliders")]
    //[SerializeField] Slider[] sliders;

    [SerializeField] int TargetMoney;
    [SerializeField] int currentProfit;
    [SerializeField] int totalProfit;
    [SerializeField] int Successes;

    [SerializeField] Level reqs;
    int level;
    int index;
    int random;

    void Start()
    {
        reqs = GetComponent<Level>();
        BaseAchievements();
        startYear.onClick.AddListener(() =>
        {
            //CollectedMoney = algorithm((int)Cuppuccino.value, (int)SpendingOnPromotion.value, (int)SalaryEmployee.value, (int)Trainingspending.value);
            currentProfit = reqs.Algorithm();
            totalProfit += currentProfit;
            int starRate = Random.Range(0, 5);
            DecisionMaking.gameObject.SetActive(false);
            Debug.Log(starRate);
            for (int i = 0; i < starRate; i++)
            {
                employeeStars[i].SetActive(true);
                customerStars[i].SetActive(true);
            }
            Debug.Log(CollectedMoney);
            if (currentProfit >= TargetMoney)
            {
                Success();
            }
            if (currentProfit < TargetMoney)
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
            ResultsUI.gameObject.SetActive(false);
            if (Successes >= 3)
            {
                NextLevel.gameObject.SetActive(true) ;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            for (int i = 0; i < 5; i++)
            {
                employeeStars[i].SetActive(false);
                customerStars[i].SetActive(false);
            }
        });

        Continue.onClick.AddListener(() =>
        {
            reqs = GetComponent<Level>();
            reqs.reqs = FindObjectOfType<Requirements>();
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
        if(level != reqs.achieve.Level)
        {
            ScaleBaseAchievements();
        }
    }

    void BaseAchievements()
    {
        level = reqs.achieve.Level;
        reqs.achieve.cur_SoldDrinks = reqs.achieve.SoldDrinks;
        reqs.achieve.cur_Revenues = reqs.achieve.Revenues;
        reqs.achieve.cur_Costs = reqs.achieve.Costs;
        reqs.achieve.cur_Profit = reqs.achieve.Profit;
    }

    public void ScaleBaseAchievements()
    {

    }

    /*public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
        return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }*/

    public void Success()
    {
        ResultsUI.gameObject.SetActive(true);
        ProfitText.text = "Profit Made: " + currentProfit;
        Successes += 1;
    }

    public void Failed()
    {
        ResultsUI.gameObject.SetActive(true);
        ProfitText.text = "Profit Made: " + currentProfit;
        Successes = 0;
    }

    //--------------------------------DEPRACATED-------------------------------
    /*  
      public float algorithm(Slider[] test)
    {
        for (int i = 0; i < test.Length; i++)
        {
            float current = test[i].value;
            if (i == 0)
            {
                float result = current * test[i + 1].value;
                currentProfit = (int)result;
            }
            if (i > 0)
            {
                //float result = current * profitMade;
                currentProfit += (int)current * currentProfit;
            }
            /*else
            {
                profitMade += (int)current * (int)test[i].value;
            }

            //In here I will be making required values for each year..and then i will check wih if statement how far they are from the required numbers
            //After that it will determine if they are too less or too high on the numbers, it means its bad and will affect the results badly..
            //If they are close enough to the numbers required, then it will have better results.
        }
        return currentProfit;
    }*/

    /*public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
    return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }*/
}