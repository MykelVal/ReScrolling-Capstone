using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceSlider : MonoBehaviour
{
    public int resourceValue;
    public Slider resourceSlider;
    public TextMeshProUGUI resourceText;

    public void SetResource()
    {
        resourceSlider.value = resourceValue;                   //sets the slider's value to the current resource value - possibly remove later and just directly use resourceSlider.value
        //resourceText.text = $"{resourceSlider.value}%";         //sets the text of the resource to the current value
    }

    public void ChangeResourceValue(int toAdd)
    {
        resourceValue += toAdd;                                 //adds the passed value to the current resource value
        Mathf.Clamp(resourceValue, 0, 100);                     //limits value to not exceed 0 and 100
        SetResource();                                          //updates the current text to the new value
    }

    #region Testing
    //you can access this by rightclicking the component and selecting the function
    //testing change of value
    [ContextMenu ("Add Stress")]
    void AddStress()
    {
        ChangeResourceValue(12);
    }
    [ContextMenu("Subtract Stress")]
    void SubtractStress()
    {
        ChangeResourceValue(-12);
    }
    #endregion
}
