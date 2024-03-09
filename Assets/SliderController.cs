using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public RGBController knob;
    public Transform rightBound;
    public Transform leftBound;
    public float progress;

    public void Start()
    {
        progress = (knob.transform.position.x - leftBound.position.x) / (rightBound.position.x - leftBound.position.x);
        Debug.Log(progress);
    }

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

    public void Click()
    {
        GameObject.FindObjectOfType<SoundController>().Play(0);
    }
    
    public void Drag() {
        RectTransform tr = GetComponent<RectTransform>();

        knob.transform.position = new Vector3(Mathf.Max(Mathf.Min(Input.mousePosition.x, rightBound.position.x), leftBound.position.x), knob.transform.position.y);
        progress = (knob.transform.position.x - leftBound.position.x) / (rightBound.position.x - leftBound.position.x);
        Debug.Log(progress);
    }
    public void EndDrag() {
        // Debug.Log(Input.mousePosition);
    }
}
