using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE4Controller : MonoBehaviour
{
    public GameObject QTE4 = null;


    public void Start()
    {
        QTE4.SetActive(false);

        StartCoroutine(WaitBeforeShow4());
    }

    private void ShowQTE4()
    {
        QTE4.SetActive(true);



    }

    IEnumerator WaitBeforeShow4()
    {
        yield return new WaitForSeconds(40);
        QTE4.SetActive(true);

        yield return new WaitForSeconds(20);
        QTE4.SetActive(false);


    }
}

