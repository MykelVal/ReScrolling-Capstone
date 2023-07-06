using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTitles : MonoBehaviour
{

    [SerializeField] GameObject[] textPrefab;
    [SerializeField] float secondSpawn = 5f;
    [SerializeField] Transform titlePos;

    public bool isThereTitle;
    public GameObject titleObject;

    void Update()
    {
        if (!isThereTitle && FindObjectOfType<UIManager>().gameObject.GetComponent<UIManager>().isInMainPanel) //
        {
            isThereTitle = true;
            StartCoroutine(TextSpawn());
        }

    }

    IEnumerator TextSpawn()
    {
        while (isThereTitle)
        {
       
            titleObject = Instantiate(textPrefab[Random.Range(0, textPrefab.Length)], titlePos.position, Quaternion.identity);
            titleObject.transform.SetParent(titlePos);
            titleObject.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(secondSpawn);
            DestroyTitle();
        }
    }

    public void DestroyTitle()
    {
        Destroy(titleObject, 0.1f);
        isThereTitle = false;
    }


}

