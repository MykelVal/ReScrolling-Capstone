using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource lightClick;
    [SerializeField] private AudioSource heavyClick;
    [SerializeField] private AudioSource hold;
    [SerializeField] private AudioSource popup;

    public void PlayLightClick()
    {
        lightClick.Play();
    }

    public void PlayHeavyClick()
    {
        lightClick.Play();
    }

    public void PlayHold()
    {
        lightClick.Play();
    }

    public void PlayPopup()
    {
        lightClick.Play();
    }
}
