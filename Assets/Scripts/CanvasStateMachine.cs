using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStateMachine : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> openedWindows = new List<GameObject>();
    public GameObject currentWindow;

    public void OpenWindow(GameObject window)
    {
        foreach (ButtonController buttonController in GameObject.FindObjectsOfType<ButtonController>())
        {
            buttonController.HoverExit();
        }
        
        if (currentWindow)
        {
            currentWindow.SetActive(false);
        }
        window.SetActive(true);
        currentWindow = window;
        openedWindows.Add(window);
    }
    
    public void CloseWindow()
    {
        foreach (ButtonController buttonController in GameObject.FindObjectsOfType<ButtonController>())
        {
            buttonController.HoverExit();
        }
        
        Debug.Log(openedWindows.Count);
        currentWindow.SetActive(false);
        if (openedWindows.Count >= 2)
        {
            GameObject lastWindow = openedWindows[openedWindows.Count - 2];
            lastWindow.SetActive(true);
            currentWindow = lastWindow;
        }   
        openedWindows.Remove(openedWindows[openedWindows.Count - 1]);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openedWindows.Count == 0)
            {
                OpenWindow(pauseMenu);
            }
            else
            {
                CloseWindow();
            }
        }
    }
}
