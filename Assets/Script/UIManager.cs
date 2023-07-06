using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainGameParent;
    [SerializeField] GameObject focusMinigameParent;
    [SerializeField] randomImages randomImages;
    [SerializeField] RandomTitles randomTitles;
    [SerializeField] BlockInput blockInput;
    [SerializeField] GameObject pausePanel;
    [SerializeField] TextMeshProUGUI productivityText;

    public bool isInMainPanel;
    private bool isPaused = false;

    private void Awake()
    {
        CoroutineManager.Initialize(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void MainGameToFocusPanel()
    {
        randomImages.DestroyImage();
        randomTitles.DestroyTitle();
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

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        CoroutineManager.PauseAllCoroutines();
        blockInput.ToggleBlockInput(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        CoroutineManager.ResumeAllCoroutines();
        blockInput.ToggleBlockInput(false);
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            ResumeGame();
            pausePanel.SetActive(false);
        }
        else
        {
            PauseGame();
            pausePanel.SetActive(true);
        }
    }

    public void UpdateProductivity()
    {
        productivityText.text = $"{FocusMeter.taskDone} / 3";
    }
}
