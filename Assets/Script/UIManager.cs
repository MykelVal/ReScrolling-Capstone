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

    [SerializeField] GameObject loadingPanel;
    [SerializeField] Image loadBar;
    [SerializeField] TextMeshProUGUI loadingText;

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

        UpdateProductivity();
    }

    public void MainGameToFocusPanel()
    {
        randomImages.DestroyImage();
        randomTitles.DestroyTitle();
        isInMainPanel = false;
        mainGameParent.SetActive(false);
        LoadScreen(focusMinigameParent, "Going to do tasks...");
        StartCoroutine(LoadingScreenWait(focusMinigameParent));
    }

    public void FocusPanelToMainGame()
    {
        isInMainPanel = true;
        focusMinigameParent.SetActive(false);
        LoadScreen(mainGameParent, "Back to scrolling...");
    }

    public void LoadScreen(GameObject newPanel, string newText)
    {
        //change text
        loadingText.text = newText;

        StartCoroutine(LoadingScreenWait(newPanel));
    }

    IEnumerator LoadingScreenWait(GameObject newPanel)
    {
        loadBar.fillAmount = 0;
        loadingPanel.SetActive(true);
        // Set the starting and target fill amount
        float startFillAmount = loadBar.fillAmount;
        float targetFillAmount = 1f; // Target fill amount is 1 since it represents 100%

        // Set the duration of the loading process (2 seconds in this case)
        float duration = 2f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float percentage = Mathf.Clamp01(timer / duration);
            float currentFillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, percentage);

            // Apply the smooth fill amount to the loading bar
            loadBar.fillAmount = currentFillAmount;

            yield return null;
        }

        // Ensure the loading bar is fully filled before hiding the transition panel
        loadBar.fillAmount = targetFillAmount;

        loadingPanel.SetActive(false);
        newPanel.SetActive(true);
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
