using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public RGBController knob;
    public void Hover() {
        knob.aberrateX = 12;
        knob.aberrateY = 12;
    }

    public void HoverExit() {
        knob.aberrateX = 0;
        knob.aberrateY = 0;
    }

    public void BeginDrag() {
        // Debug.Log(Input.mousePosition);
    }
    public void Drag() {
        // Debug.Log(Input.mousePosition.x);
        // RectTransform tr = GetComponent<RectTransform>();
        // Debug.Log(tr.localPosition.x);
        knob.transform.position = new Vector3(Input.mousePosition.x, knob.transform.position.y);
    }
    public void EndDrag() {
        // Debug.Log(Input.mousePosition);
    }
}
