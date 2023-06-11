using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FocusTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public float timer;
    public float totalTime;

    private void OnEnable()
    {
        ResetTime();
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        Debug.Log(timer);
    }

    public void DisplayTime()
    {
        int hours = Mathf.FloorToInt(timer / 60f);                          //military time hours
        int minutes = Mathf.FloorToInt(timer - hours * 60);                 //minutes
        timeText.text = string.Format("{0:00}:{1:00}", hours, minutes);     //display the time with 0's placeholding the other values
    }

    public void ResetTime()
    {
        timer = totalTime;                                                       //reset time to totalTime (in seconds)
    }

    /*public void Countdown()
    {
        timer -= Time.deltaTime;
    }*/

    private System.Collections.IEnumerator Countdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            DisplayTime();
        }

        if (timer <= 0)
        {
            // Do something when the timer finishes
        }
    }

    #region Testing
    //you can access this by rightclicking the component and selecting the function
    //for testing purposes

    #endregion
}
