using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{

    public float Money = 0;
    public float MoneyAdded = 400;
    public int StartTimer = 1;
    public float Timer = 6;
    public float TimeReset = 6;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        MoneyText.text = Money.ToString("Year");
        TimerText.text = Timer.ToString("0.0");

        if (StartTimer == 1)
        {
            Timer = Timer - 1 * Time.deltaTime;
        }

        if (Timer < -0)
        {
            Money = Money + MoneyAdded;
            Timer = TimeReset;
            StartTimer = 0;
        }

    }

    public void StartButtonClicked()
    {
        StartTimer = 1;
    }

}
