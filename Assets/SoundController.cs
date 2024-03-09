using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<AudioSource> Sources;

    public void Play(int source, float variance = 0.2f, float initialPitch = 1.0f, float time = 0.01f)
    {
        Sources[source].pitch = initialPitch - (variance)  - UnityEngine.Random.Range(0, variance);
        // Sources[source].time = Sources[source].clip.length - 0.01f;
        Sources[source].Play();
    }
}
