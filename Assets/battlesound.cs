using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlesound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
    private void Start()
    {
        source = GetComponent<AudioSource>(); // Get the AudioSource component
        source.clip = clip; // Assign the AudioClip to the AudioSource component
        source.Play(); // Play the audio clip
    }
}
