using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AberrationController : MonoBehaviour
{
    public float aberration;
    void Update()
    {
        foreach (RGBController controller in Object.FindObjectsOfType<RGBController>()) {
            controller.aberrateX = (aberration/10) * 0.2f;
            controller.aberrateY = (aberration/10) * 0.2f;
        }
    }
}
