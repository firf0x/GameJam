using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicController;
    public AudioClip music;
    void Start()
    {
    }

    private void FixedUpdate()
    {
        musicController.Play();
    }
}
