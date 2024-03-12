using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public String fileLocation;

    public void ClickFile()
    {
        PlayerPrefs.SetString("level", fileLocation);
    }

    public void EditFile()
    {
        PlayerPrefs.SetString("editing", fileLocation);
    }
}
