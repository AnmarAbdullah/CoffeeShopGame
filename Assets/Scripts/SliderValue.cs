using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI value;
    Slider myValue;

    void Start()
    {
        myValue = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        value.text = "$" + myValue.value.ToString();  
    } 
}
