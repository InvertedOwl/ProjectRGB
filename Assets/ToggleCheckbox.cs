using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCheckbox : MonoBehaviour
{
    public Toggle toggle;
    public EditorController editorController;
    public String color;

    public void Changed()
    {
        if (color == "red")
        {
            editorController.ToggleRed(toggle.isOn);
        }
        if (color == "green")
        {
            editorController.ToggleGreen(toggle.isOn);
        }
        if (color == "blue")
        {
            editorController.ToggleBlue(toggle.isOn);
        }

        if (color == "gravity")
        {
            editorController.ToggleGravity(toggle.isOn);
        }

    }
}
