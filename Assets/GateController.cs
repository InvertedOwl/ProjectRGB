using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public AberrationController controller;
    public float aberration = 2;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger Gate");
        controller.aberration = aberration;
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("HEH?");
    }
}
