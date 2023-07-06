using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleBlockInput(bool block)
    {
        gameObject.SetActive(block);
    }
}
