using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour
{
    public String colorToRemove;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            foreach (Transform child in col.transform)
            {
                Debug.Log(child.parent.gameObject.layer +", "+ colorToRemove);
                if (child.parent.gameObject.layer == LayerMask.NameToLayer(colorToRemove))
                {
                    child.parent.gameObject.active = false;
                }
            }
        }
    }
}
