using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusMeter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    [Header("Tasks")]
    [SerializeField] Transform task;
    float taskPosition;
    float taskDestination;
    float turnTimer;
    [SerializeField] float timeMultiplier = 3f;
    float taskSpeed;
    [SerializeField] float smoothing = 1f;

    [Header("Focus")]
    [SerializeField] Transform focus;
    float focusPosition;
    [SerializeField] float focusSize = 0.1f;
    float focusPullVelocity;
    [SerializeField] float focusPullPower = 0.1f;
    [SerializeField] float focusGravityPower = 0.005f;

    [Header("Progress Bar")]
    float focusProgress;
    [SerializeField] float focusProgressDegradationPower = 0.1f;
    [SerializeField] float focusPower = 0.15f;
    [SerializeField] Transform progressBar;

    [Header("Resources")]
    [SerializeField] private ResourceSlider productivityObject;
    [SerializeField] private ResourceTime timeObject;

    private void Start()
    {
        SetSize();
        focusProgress = 0f;
    }
    private void FixedUpdate()
    {
        MoveTaskIcon();             //moves the chasee
        MoveFocusBar();             //controls the chaser
        ProgressCheck();            //controls the progress bar
    }

    private void SetSize()
    {
        focus.localScale = new Vector3(focusSize, 1, 1);
        
        /*Vector2 ls = focus.localScale;
        float distance = Vector2.Distance(leftPoint.position, rightPoint.position);
        ls.x = (distance / xSize * focusSize);
        focus.localScale = ls;*/
    }

    private void MoveTaskIcon()
    {
        turnTimer -= Time.deltaTime;            //countdown for when the chasee/task changes position
        if (turnTimer < 0)
        {
            turnTimer = UnityEngine.Random.value * timeMultiplier;              //sets a random time based on the timeMultiplier (in seconds)

            taskDestination = UnityEngine.Random.value;             //sets a random value between 0 - 1 which will be the new target destination of the chasee/task
        }

        taskPosition = Mathf.SmoothDamp(taskPosition, taskDestination, ref taskSpeed, smoothing);               //smoothens the movement of the chasee/task as it approaches the target destination
        task.position = Vector2.Lerp(leftPoint.position, rightPoint.position, taskPosition);
    }

    private void MoveFocusBar()
    {
        if (focusPosition == focusSize / 2 || focusPosition >= 1 - (focusSize / 2) - 0.001)                  //sets the velocity of the chaser/focus to 0 if its at the edge
        {
            focusPullVelocity = 0f;
        }

        if (Input.GetMouseButton(0))                //adds focusPullPower to increase the velocity
        {
            if (focusPosition <= 1 - focusSize / 2)
            {
                focusPullVelocity += focusPullPower * Time.deltaTime;
            }
        }
        if (focus.position != leftPoint.position)               //subtracts focusGravityPower to decrease the velocity
        {
            focusPullVelocity -= focusGravityPower * Time.deltaTime;
        }
       
        Debug.Log(focusPullVelocity);

        focusPullVelocity = Mathf.Clamp(focusPullVelocity, -0.05f, 0.05f);
        focusPosition += focusPullVelocity;
        focusPosition = Mathf.Clamp(focusPosition, focusSize / 2, 1 - focusSize / 2);
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
        if (focusProgress >= 1f)
        {
            ProgressFull();
        }
    }

    private void ProgressFull()
    {
        productivityObject.ChangeResourceValue(25);
        timeObject.AddTime(120);        //to change according to how long task was done
        FindObjectOfType<UIManager>().FocusPanelToMainGame();
    }
}
