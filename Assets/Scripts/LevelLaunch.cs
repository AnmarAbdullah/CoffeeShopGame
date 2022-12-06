using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLaunch : MonoBehaviour
{
    public int levelNumber;

    public void StartGame()
    {
        SceneManager.LoadScene("Level " + levelNumber);
    }
}
