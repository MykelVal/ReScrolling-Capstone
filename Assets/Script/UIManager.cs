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

    public void MainGameToFocusPanel()
    {
        Destroy(randomImages.gameObject);
        mainGameParent.SetActive(false);
        focusMinigameParent.SetActive(true);
    }

    public void FocusPanelToMainGame()
    {
        mainGameParent.SetActive(true);
        focusMinigameParent.SetActive(false);
    }

}
