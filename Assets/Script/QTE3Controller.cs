using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE3Controller : MonoBehaviour
{
    public GameObject QTE3 = null;


    public void Start()
    {
        QTE3.SetActive(false);

        StartCoroutine(WaitBeforeShow3());
    }

    private void ShowQTE3()
    {
        QTE3.SetActive(true);



    }

    IEnumerator WaitBeforeShow3()
    {
        yield return new WaitForSeconds(30);
        QTE3.SetActive(true);

        yield return new WaitForSeconds(15);
        QTE3.SetActive(false);


    }
}
