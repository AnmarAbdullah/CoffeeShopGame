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
    [SerializeField] GameObject DecisionMaking;
    [SerializeField] GameObject NextLevel;
    [SerializeField] GameObject PauseMenu;
    bool paused;

    [SerializeField] int currentYear = 1;
    
    [Header("Buttons")]
    [SerializeField] Button startYear;
    [SerializeField] Button nextYear;
    [SerializeField] Button Continue;
    [SerializeField] Button backButton;
    [SerializeField] Button nextLevel;
    
    [Header("Sliders")]
    [SerializeField] int TargetMoney;
    [SerializeField] int currentProfit;
    [SerializeField] int totalProfit;
    [SerializeField] int Successes;

    [SerializeField] Level reqs;
    public int level;
    int index;
    int random;

    void Start()
    {
        SaveSystem.SavePlayer(this);
        reqs = GetComponent<Level>();
        BaseAchievements();
        startYear.onClick.AddListener(() =>
        {
            //CollectedMoney = algorithm((int)Cuppuccino.value, (int)SpendingOnPromotion.value, (int)SalaryEmployee.value, (int)Trainingspending.value);
            currentProfit = reqs.Algorithm();
            Debug.Log(currentProfit);
            reqs.Results();
            totalProfit += currentProfit;
            int starRate = Random.Range(0, 5);
            DecisionMaking.gameObject.SetActive(false);
            if (totalProfit >= TargetMoney)
            {
                NextLevel.gameObject.SetActive(true);
            }
            Success();
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
            /*if (Successes >= 3)
            {
                NextLevel.gameObject.SetActive(true) ;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }*/
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
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseMenu.SetActive(true);
        }
        if (!paused)
        {
            PauseMenu.SetActive(false);
        }
    }

    void BaseAchievements()
    {
        //level = reqs.achieve.Level;
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
        Successes += 1;
    }

    public void Failed()
    {
        ResultsUI.gameObject.SetActive(true);
        Successes = 0;
    }

    public void BackToMainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Resume()
    {
        paused = !paused;
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

        }
        return currentProfit;
    }*/

    /*public int algorithm(int cuppuccinoPrice, int spendingOnPromo, int EmployeeSalary, int TrainSpending)
    {
    return cuppuccinoPrice * spendingOnPromo * EmployeeSalary * TrainSpending;
    }*/
}