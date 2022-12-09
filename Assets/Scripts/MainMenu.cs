using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int lastLevelReached;
    [SerializeField] GameObject[] unlockLevel;
    [SerializeField] Slider volumeSlider; 

    public void QuitGame()
    {
       Application.Quit();
    }

    public void LoadProgress()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        lastLevelReached = data.Level;
        for (int i = 0; i < lastLevelReached; i++)
        {
            if (i == lastLevelReached) continue;
            unlockLevel[i].gameObject.SetActive(false);        
        }
    }

    void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
