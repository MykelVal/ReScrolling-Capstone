using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    [SerializeField] private float startingTime = 10f;

    [SerializeField] Text countdownText;
    [SerializeField] ButtonBehavior buttonBehavior;
  
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            buttonBehavior.TimerDamageStress();
            Destroy(gameObject);
        }
    }
}
