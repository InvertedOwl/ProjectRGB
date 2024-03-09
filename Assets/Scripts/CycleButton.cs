using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CycleButton : MonoBehaviour
{
    public List<Vector2> resolutions;
    private int selectedIndex;
    public TMP_Text textObject;
    public String text;
    public ToggleButton fullscreen;
    
    void Start()
    {
        int currentWidth = Screen.width;
        int currentHeight = Screen.height;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].x == currentWidth && resolutions[i].y == currentHeight)
            {
                selectedIndex = i;
            }
        }

        UpdateText();
    }


    public void UpdateText()
    {
        textObject.text = text + " " + resolutions[selectedIndex].x + "x" + resolutions[selectedIndex].y;
        Screen.SetResolution((int) resolutions[selectedIndex].x, (int) resolutions[selectedIndex].y, (fullscreen.enabled)?FullScreenMode.FullScreenWindow:FullScreenMode.Windowed);
    }
    
    public void Clicked()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            selectedIndex -= 1;
        }
        else
        {
            selectedIndex += 1;
        }
        selectedIndex = selectedIndex % resolutions.Count;
        UpdateText();
    }
    
}
