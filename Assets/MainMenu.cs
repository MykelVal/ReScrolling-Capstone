using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Second Merge");
    }

    public void ExitGame()
    {
        Debug.Log("Exited Game");
        Application.Quit();
    }
}
