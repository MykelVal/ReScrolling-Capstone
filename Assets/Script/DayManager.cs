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

    private void Awake()
    {
        dayPanel.SetActive(false);
    }

    private void Update()
    {
        CheckTime();
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
