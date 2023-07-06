using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;
    private static List<Coroutine> activeCoroutines = new List<Coroutine>();
    private static MonoBehaviour coroutineOwner;

    public static void Initialize(MonoBehaviour owner)
    {
        if (instance == null)
        {
            GameObject managerObject = new GameObject("CoroutineManager");
            instance = managerObject.AddComponent<CoroutineManager>();
            DontDestroyOnLoad(managerObject);
        }

        coroutineOwner = owner;
    }

    public static Coroutine StartCoroutine(IEnumerator routine)
    {
        Coroutine coroutine = coroutineOwner.StartCoroutine(instance.InternalStartCoroutine(routine));
        activeCoroutines.Add(coroutine);
        return coroutine;
    }

    public static void StopCoroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            coroutineOwner.StopCoroutine(coroutine);
            activeCoroutines.Remove(coroutine);
        }
    }

    public static void PauseAllCoroutines()
    {
        foreach (Coroutine coroutine in activeCoroutines)
        {
            coroutineOwner.StopCoroutine(coroutine);
        }
        activeCoroutines.Clear();
    }

    public static void ResumeAllCoroutines()
    {
        foreach (Coroutine coroutine in activeCoroutines)
        {
            coroutineOwner.StartCoroutine(instance.InternalResumeCoroutine(coroutine));
        }
    }

    private IEnumerator InternalStartCoroutine(IEnumerator routine)
    {
        Coroutine coroutine = coroutineOwner.StartCoroutine(routine);
        activeCoroutines.Add(coroutine);
        yield return coroutine;
        activeCoroutines.Remove(coroutine);
    }

    private IEnumerator InternalResumeCoroutine(Coroutine coroutine)
    {
        yield return null;
        activeCoroutines.Add(coroutine);
    }
}
