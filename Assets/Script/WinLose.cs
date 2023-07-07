using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLose : MonoBehaviour
{
    [SerializeField] private StressBar stressBar;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI tasksText;

    public bool hasWon = false;

    public static int totalTasks;

    private void Update()
    {
        CheckIfLose();
        CheckIfWin();
    }

    public void CheckIfLose()
    {
        if (stressBar.health <= 0)
        {
            //lose process
            uiManager.PauseGame();
            pauseBtn.SetActive(false);
            losePanel.SetActive(true);
        }
    }

    public void CheckIfWin()
    {
        if (hasWon)
        {
            //win process
            uiManager.PauseGame();
            pauseBtn.SetActive(false);
            winPanel.SetActive(true);
            healthText.text = $"Remaining Health: {stressBar.health}";
            tasksText.text = $"Total Tasks Done: {totalTasks} / 15";

            DayManager.day = 1;
            ResourceTime.timer = 480f;
        }
    }
}
