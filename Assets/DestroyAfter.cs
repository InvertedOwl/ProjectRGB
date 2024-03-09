using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{

    public float seconds;
    public AudioSource playImmediate;

    public void Start()
    {
        playImmediate.Play();
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
