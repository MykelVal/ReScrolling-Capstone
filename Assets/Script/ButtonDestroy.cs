using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        Destroy(objectToDestroy);
    }
}
