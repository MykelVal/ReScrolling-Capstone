using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainGameParent;
    [SerializeField] GameObject focusMinigameParent;

    public void MainGameToFocusPanel()
    {
        mainGameParent.SetActive(false);
        focusMinigameParent.SetActive(true);
    }

    public void FocusPanelToMainGame()
    {
        mainGameParent.SetActive(true);
        focusMinigameParent.SetActive(false);
    }

}
