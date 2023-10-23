using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSound1 : MonoBehaviour
{
    public AudioSource audioSource;

    public void playButton()
    {
        audioSource.Play();
    }
}
