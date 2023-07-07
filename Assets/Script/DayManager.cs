using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayManager : MonoBehaviour
{
    public static int day = 1;
    [SerializeField] private GameObject dayPanel;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private WinLose winLose;

    private void Awake()
    {
        dayPanel.SetActive(false);
    }

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
            CoroutineManager.PauseAllCoroutines();
            day++;
            ResourceTime.timer = 480;
            FocusMeter.TasksReset();
            StartCoroutine(DayTransition());
            CoroutineManager.ResumeAllCoroutines();
        }
    }

    IEnumerator DayTransition()
    {
        dayText.text = $"Day {day}";
        dayPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        dayPanel.SetActive(false);
    }
}
