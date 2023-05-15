using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public float timer;

    private void Update()
    {
        Debug.Log(timer);
        DisplayTime();                  //will probably remove for optimization, will only call the function after a task ends
    }

    public void DisplayTime()
    {
        int hours = Mathf.FloorToInt(timer / 24f);                          //military time hours
        int minutes = Mathf.FloorToInt(timer - hours * 60);                 //minutes
        timeText.text = string.Format("{0:00}:{1:00}", hours, minutes);     //display the time with 0's placeholding the other values
    }

    public void AddTime(float value)
    {
        timer += value;
    }

    #region Testing
    //you can access this by rightclicking the component and selecting the function
    //for testing purposes
    [ContextMenu ("Add15")]
    public void Add15()
    {
        AddTime(15);
    }
    [ContextMenu("Add30")]
    public void Add30()
    {
        AddTime(30);
    }
    [ContextMenu("Add60")]
    public void Add60()
    {
        AddTime(60);
    }
    #endregion
}
