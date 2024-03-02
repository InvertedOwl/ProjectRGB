using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Player died");
            StartCoroutine(GameObject.FindObjectOfType<LevelController>().LoadLevelWait(GameObject.FindObjectOfType<LevelController>().currentLevel));
        }
    }
}
