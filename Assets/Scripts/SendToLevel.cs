using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToLevel : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(GameObject.FindObjectOfType<LevelController>().LoadLevelWait(level));
        }
    }
}
