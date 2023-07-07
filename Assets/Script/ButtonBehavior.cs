using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private StressBar stressResource;
    private UIManager uiManager;
    private ResourceTime resourceTime;
    private QTEManager qteManager;
    private AudioPlayer audioPlayer;

    private GameObject stressObject;
    private GameObject uiManagerObject;
    private GameObject resourceTimeObject;
    private GameObject qteManagerObject;
    private GameObject audioPlayerObject;

    [SerializeField] private float damageValue = 10f;
    [SerializeField] private float timerDamage = 5f;
    [SerializeField] private GameObject objectToDestroy;

    //if pressed yes, minus stress
    //if pressed no, bring up minigame

    private void Start()
    {
        stressObject = FindObjectOfType<StressBar>().gameObject;
        uiManagerObject = FindObjectOfType<UIManager>().gameObject;
        resourceTimeObject = FindObjectOfType<ResourceTime>().gameObject;
        qteManagerObject = FindObjectOfType<QTEManager>().gameObject;
        audioPlayerObject = FindObjectOfType<AudioPlayer>().gameObject;

        stressResource = stressObject.GetComponent<StressBar>();
        uiManager = uiManagerObject.GetComponent<UIManager>();
        resourceTime = resourceTimeObject.GetComponent<ResourceTime>();
        qteManager = qteManagerObject.GetComponent<QTEManager>();
        audioPlayer = audioPlayerObject.GetComponent<AudioPlayer>();
    }

    public void DamageStress()
    {
        stressResource.Damage(damageValue);
    }

    public void TimerDamageStress()
    {
        stressResource.Damage(timerDamage);
    }

    public void MainGameToFocusPanel()
    {
        uiManager.MainGameToFocusPanel();
    }

    public void DestroyQTE()
    {
        CheckIfEnoughForMinigame();
        Destroy(objectToDestroy);
    }

    public void ProgressTime()
    {
        resourceTime.AddTime(60);
    }

    public void CheckIfEnoughForMinigame()
    {
        if (qteManager.countQTE >= qteManager.maxCountQTE && FocusMeter.taskDone < 3)
        {
            qteManager.countQTE = 0;
            uiManager.MainGameToFocusPanel();
        }
    }

    public void PlayClick()
    {
        audioPlayer.PlayHeavyClick();
    }
}
