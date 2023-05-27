using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE2Controller : MonoBehaviour
{
    public GameObject QTE2 = null;


    public void Start()
    {
        QTE2.SetActive(false);

        StartCoroutine(WaitBeforeShow2());
    }

    private void ShowQTE2()
    {
        QTE2.SetActive(true);



    }

    IEnumerator WaitBeforeShow2()
    {
        yield return new WaitForSeconds(20);
        QTE2.SetActive(true);

        yield return new WaitForSeconds(10);
        QTE2.SetActive(false);


    }
}