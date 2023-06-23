using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy;

    public void whenButtonClicked()
    {
        if (objectToDestroy.activeInHierarchy == true)
            objectToDestroy.SetActive(false);
        else
            objectToDestroy.SetActive(true);
    }
}
