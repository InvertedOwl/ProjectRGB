using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    public TMP_Text textObject;
    public String text;
    public bool enabled;
    public UnityEvent clicked;
    
    public void Clicked()
    {
        enabled = !enabled;
        if (enabled)
        {
            textObject.text = text + "[X]";
        }
        else
        {
            textObject.text = text + "[  ]";
        }
        clicked.Invoke();
    }
}
