using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public ToggleButton toggle;

    public void Clicked()
    {
        Screen.fullScreen = toggle.enabled;
        Debug.Log(((toggle.enabled)?"Enabled":"Disabled") + " fullscreen");
    }
}
