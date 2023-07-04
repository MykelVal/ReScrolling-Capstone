using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private StressBar stressResource;
    private UIManager uiManager;
    private GameObject stressObject;
    private GameObject uiManagerObject;

    [SerializeField] private float damageValue = 10f;
    [SerializeField] private GameObject objectToDestroy;

    //if pressed yes, minus stress
    //if pressed no, bring up minigame

    private void Start()
    {
        stressObject = FindObjectOfType<StressBar>().gameObject;
        uiManagerObject = FindObjectOfType<UIManager>().gameObject;
        stressResource = stressObject.GetComponent<StressBar>();
        uiManager = uiManagerObject.GetComponent<UIManager>();
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
        Destroy(objectToDestroy);
    }
}
