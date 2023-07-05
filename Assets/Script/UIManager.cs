using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainGameParent;
    [SerializeField] GameObject focusMinigameParent;
    [SerializeField] randomImages randomImages;

    public bool isInMainPanel;

    public void MainGameToFocusPanel()
    {
        randomImages.DestroyImage();
        isInMainPanel = false;
        mainGameParent.SetActive(false);
        focusMinigameParent.SetActive(true);
    }

    public void FocusPanelToMainGame()
    {
        isInMainPanel = true;
        mainGameParent.SetActive(true);
        focusMinigameParent.SetActive(false);
    }

}
