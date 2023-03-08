using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

    [SerializeField] AudioClip nightSound;
    [SerializeField] AudioClip daySound;
    [SerializeField] AudioSource audioSource;
    public void NightSound() 
    {
        audioSource.clip = nightSound;
        audioSource.Play();
    }

    public void DaySound() 
    {
        audioSource.clip = daySound;
        audioSource.Play();
    }
}
