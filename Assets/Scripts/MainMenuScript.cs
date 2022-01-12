using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
    public int CurLevel;

    private void Start()
    {
        CurLevel = CL.CurrentLevel;
        Debug.Log(CurLevel);
    }

    public void StartLevel(int numLevel)
    {
        SceneManager.LoadScene(numLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Game is closed"); // TODO ”ничтожить строку на билде
        Application.Quit();
    }

    public void GiveCurLevel(int currentLevel)
    {
        if(currentLevel >= CL.CurrentLevel)
            CL.CurrentLevel = currentLevel;
    }
}
