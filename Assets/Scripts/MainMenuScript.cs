using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int curLevel;
    public void StartLevel()
    {
        SceneManager.LoadScene(curLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Game is closed"); // TODO ”ничтожить строку на билде
        Application.Quit();
    }

    public void GiveCurrentScene(int curSc)
    {
        curLevel = curSc;
        Debug.Log(curLevel); // TODO ”ничтожить строку на билде
    }
}
