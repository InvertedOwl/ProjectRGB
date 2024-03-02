using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AberrationController : MonoBehaviour
{
    public float aberrationX;
    public float aberrationY;
    void Update()
    {
        foreach (RGBController controller in Object.FindObjectsOfType<RGBController>())
        {
            if (!controller.acceptGlobalEditing) continue;
            controller.aberrateX = (aberrationX/10) * 0.2f;
            controller.aberrateY = (aberrationY/10) * 0.2f;
        }
    }
}
