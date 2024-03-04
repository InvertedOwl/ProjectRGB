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
            // other.transform.parent.GetChild(0).GetComponent<LerpScale>().targetScale = 0;
            // other.transform.parent.GetChild(1).GetComponent<LerpScale>().targetScale = 0;
            // other.transform.parent.GetChild(2).GetComponent<LerpScale>().targetScale = 0;
        }
    }
}
