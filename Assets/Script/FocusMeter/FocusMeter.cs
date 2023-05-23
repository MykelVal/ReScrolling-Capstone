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

    [SerializeField] Transform focus;
    float focusPosition;
    [SerializeField] float focusSize = 0.1f;
    [SerializeField] float focusPower = 0.15f;
    float focusProgress;
    float focusPullVelocity;
    [SerializeField] float focusPullPower = 0.1f;
    [SerializeField] float focusGravityPower = 0.005f;
    [SerializeField] float focusProgressDegradationPower = 0.1f;

    [SerializeField] Transform progressBar;
    private void FixedUpdate()
    {
        MoveTaskIcon();
        MoveFocusBar();
        ProgressCheck();
    }

    private void MoveTaskIcon()
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

    private void MoveFocusBar()
    {
        if (Input.GetMouseButton(0))
        {
            focusPullVelocity += focusPullPower * Time.deltaTime;
        }
        focusPullVelocity -= focusGravityPower * Time.deltaTime;
        focusPullVelocity = Mathf.Clamp(focusPullVelocity, -0.0f, 0.01f);
        Debug.Log(focusPullVelocity);

        focusPosition += focusPullVelocity;
        focusPosition = Mathf.Clamp(focusPosition, 0, 1);
        focus.position = Vector2.Lerp(leftPoint.position, rightPoint.position, focusPosition);
    }

    private void ProgressCheck()
    {
        Vector2 ls = progressBar.localScale;
        ls.x = focusProgress;
        progressBar.localScale = ls;

        float min = focusPosition - focusSize / 2;
        float max = focusPosition + focusSize / 2;

        if (min < taskPosition && taskPosition < max)
        {
            focusProgress += focusPower * Time.deltaTime;
        }
        else
        {
            focusProgress -= focusProgressDegradationPower * Time.deltaTime;
        }

        focusProgress = Mathf.Clamp(focusProgress, 0f, 1f);
    }
}
