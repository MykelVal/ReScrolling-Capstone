using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    //[SerializeField] private List<GameObject> QTE = new List<GameObject>();
    [SerializeField] private GameObject QTEPrefab;
    [SerializeField] private Transform QTEPos;

    //countdown to next qte
    //instantiate qteprefab
    //stop countdown
    //start timer for current qte
    //turn off qte after timer
    //start countdown to next qte

    public void Start()
    {
        //countdown to next qte
        StartCoroutine(WaitBeforeShowingQTE());
    }

    private void ShowQTE()
    {
    }

    IEnumerator WaitBeforeShowingQTE()
    {
        yield return new WaitForSeconds(10);
        //instantiate qteprefab
        GameObject gameObject = Instantiate(QTEPrefab, QTEPos.position, Quaternion.identity);
    }
}
