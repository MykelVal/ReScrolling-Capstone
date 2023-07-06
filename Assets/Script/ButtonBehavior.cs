using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private StressBar stressResource;
    private UIManager uiManager;
    private ResourceTime resourceTime;
    private QTEManager qteManager;
    private GameObject stressObject;
    private GameObject uiManagerObject;
    private GameObject resourceTimeObject;
    private GameObject qteManagerObject;

    [SerializeField] private float damageValue = 10f;
    [SerializeField] private GameObject objectToDestroy;

    //if pressed yes, minus stress
    //if pressed no, bring up minigame

    private void Start()
    {
        stressObject = FindObjectOfType<StressBar>().gameObject;
        uiManagerObject = FindObjectOfType<UIManager>().gameObject;
        resourceTimeObject = FindObjectOfType<ResourceTime>().gameObject;
        qteManagerObject = FindObjectOfType<QTEManager>().gameObject;
        stressResource = stressObject.GetComponent<StressBar>();
        uiManager = uiManagerObject.GetComponent<UIManager>();
        resourceTime = resourceTimeObject.GetComponent<ResourceTime>();
        qteManager = qteManagerObject.GetComponent<QTEManager>();
    }

    public void DamageStress()
    {
        stressResource.Damage(damageValue);
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
        if (qteManager.countQTE >= qteManager.maxCountQTE)
        {
            qteManager.countQTE = 0;
            uiManager.MainGameToFocusPanel();
        }
    }
}
