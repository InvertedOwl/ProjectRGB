using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStateMachine : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> openedWindows = new List<GameObject>();
    public GameObject currentWindow;
    public GameObject defaultWindow;

    public void OpenWindow(GameObject window)
    {
        Controller c = GameObject.FindObjectOfType<Controller>();
        if (c) {
            c.controllsEnabled = false;
        }

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
        else
        {
            GameObject.FindObjectOfType<Controller>().controllsEnabled = true;
        }
        openedWindows.Remove(openedWindows[openedWindows.Count - 1]);

    }

    public void Update()
    {
        if (openedWindows.Count == 0 && defaultWindow)
        {
            try
            {
                OpenWindow(defaultWindow);
            }
            catch (Exception iwanttobedone)
            {
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (openedWindows.Count == 0)
            {
                OpenWindow(pauseMenu);
            }
            else if (defaultWindow == null)
            {
                CloseWindow();
            }
            else
            {
                OpenWindow(defaultWindow);
            }
        }
    }
}
