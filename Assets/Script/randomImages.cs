using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomImages : MonoBehaviour
{
    [SerializeField] GameObject[] imagePrefab;
    [SerializeField] float secondSpawn = 5f;
    public GameObject gameObject;
   
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ImageSpawn());
    }

    IEnumerator ImageSpawn()
    {
        while (true)
        {
       
            gameObject = Instantiate(imagePrefab[Random.Range(0, imagePrefab.Length)]);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 0.1f);
        }
    }


}

  
