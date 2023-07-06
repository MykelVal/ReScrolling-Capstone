using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomImages : MonoBehaviour
{
    [SerializeField] GameObject[] imagePrefab;
    [SerializeField] float secondSpawn = 5f;
    [SerializeField] Transform newsPos;

    public GameObject imageObject;

    public bool isThereImage;

    // Start is called before the first frame update
    void Update()
    {
        if (!isThereImage && FindObjectOfType<UIManager>().gameObject.GetComponent<UIManager>().isInMainPanel) //
        {
            isThereImage = true;
            StartCoroutine(ImageSpawn());
        }
        
    }

    IEnumerator ImageSpawn()
    {
        while (isThereImage)
        {
            imageObject = Instantiate(imagePrefab[Random.Range(0, imagePrefab.Length)], newsPos.position, Quaternion.identity);
            imageObject.transform.SetParent(newsPos);
            imageObject.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(secondSpawn);
            DestroyImage();
        }
    }

    public void DestroyImage()
    {
        Destroy(imageObject, 0.1f);
        isThereImage = false;
    }
}

  
