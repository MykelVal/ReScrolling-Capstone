using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayManager : MonoBehaviour
{
    public static int day = 1;
    [SerializeField] private GameObject scrollPanel;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private WinLose winLose;
    [SerializeField] private UIManager uiManager;

    public bool isNewDay = false;


    private void Update()
    {
        if (day < 5)
        {
            CheckTime();
        }
        else if (day == 5 && ResourceTime.timer >= 1200)
        {
            winLose.hasWon = true;
        }
    }

    public void CheckTime()
    {
        if (ResourceTime.timer >= 1200)
        {
            //proceed to next day
            isNewDay = true;
            CoroutineManager.PauseAllCoroutines();
            day++;
            ResourceTime.timer = 480;
            FocusMeter.TasksReset();
            scrollPanel.SetActive(false);
            uiManager.LoadScreen(scrollPanel, $"Day {day}");
            //StartCoroutine(DayTransition());
            CoroutineManager.ResumeAllCoroutines();
            isNewDay = false;
        }
    }

    /*IEnumerator DayTransition()
    {
        dayText.text = $"Day {day}";
        dayPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        dayPanel.SetActive(false);
    }*/
}
