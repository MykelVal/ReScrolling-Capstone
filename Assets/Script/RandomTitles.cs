using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTitles : MonoBehaviour
{

    [SerializeField] GameObject[] textPrefab;
    [SerializeField] float secondSpawn = 5f;
   
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(TextSpawn());
    }

    IEnumerator TextSpawn()
    {
        while (true)
        {
       
            GameObject gameObject = Instantiate(textPrefab[Random.Range(0, textPrefab.Length)]);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 0.1f);
        }
    }


}

