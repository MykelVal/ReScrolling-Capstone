using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    public GameObject QTE = null;

    public void Start()
    {
        QTE.SetActive(false);

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


    }
}
