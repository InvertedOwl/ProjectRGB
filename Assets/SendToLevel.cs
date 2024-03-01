using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToLevel : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        SceneManager.LoadScene(level);
    }
}
