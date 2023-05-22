using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMeter : MonoBehaviour
{
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    [SerializeField] Transform task;

    float taskPosition;
    float taskDestination;

    float turnTimer;
    [SerializeField] float timeMultiplier = 3f;

    float taskSpeed;
    [SerializeField] float smoothing = 1f;

    private void Update()
    {
        turnTimer -= Time.deltaTime;
        if (turnTimer < 0)
        {
            turnTimer = UnityEngine.Random.value * timeMultiplier;

            taskDestination = UnityEngine.Random.value;
        }

        taskPosition = Mathf.SmoothDamp(taskPosition, taskDestination, ref taskSpeed, smoothing);
        task.position = Vector2.Lerp(leftPoint.position, rightPoint.position, taskPosition);
    }
}
