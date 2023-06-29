using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    //[SerializeField] private List<GameObject> QTE = new List<GameObject>();
    [SerializeField] private GameObject QTEPrefab;

    //countdown to next qte
    //instantiate qteprefab
    //stop countdown
    //start timer for current qte
    //turn off qte after timer
    //start countdown to next qte

    /*public void Start()
    {
        StartCoroutine(WaitBeforeShow());
    }

    private void ShowQTE()
    {
        QTE.SetActive(true);
    }

    IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(10);
        QTE.SetActive(true);

        yield return new WaitForSeconds(5);
        QTE.SetActive(false);


    }*/
}
