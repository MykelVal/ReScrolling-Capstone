using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    //[SerializeField] private List<GameObject> QTE = new List<GameObject>();
    [SerializeField] private GameObject[] QTEPrefab;
    [SerializeField] private Transform QTEPos;

    [SerializeField] private float countdownSeconds = 10f;
    private bool countdownOngoing;
    public bool isThereAQTE;

    public int countQTE;
    public int maxCountQTE;

    private GameObject prefabObject;

    private void Update()
    {
        //see if there is a QTE in the scene
        var timerObject = FindObjectOfType(typeof(Timer));

        if (timerObject != null)
        {
            isThereAQTE = true;
        }
        else isThereAQTE = false;

        //if there is no current qte in the scene and the countdown hasnt started...
        if (!isThereAQTE && !countdownOngoing)
        {
            countdownOngoing = true;

            //start countdown
            StartCoroutine(WaitBeforeShowingQTE());
        }
    }

    IEnumerator WaitBeforeShowingQTE()
    {
        //countdown to 10 seconds
        yield return new WaitForSeconds(countdownSeconds);

        //instantiate qteprefab
        prefabObject = Instantiate(QTEPrefab[Random.Range(0, QTEPrefab.Length)], QTEPos.position, Quaternion.identity);
        //set it to be a child of QTEPos object
        prefabObject.transform.SetParent(QTEPos);
        //set scale to 1
        prefabObject.transform.localScale = Vector3.one;

        countQTE++;
        countdownOngoing = false;
    }
}
