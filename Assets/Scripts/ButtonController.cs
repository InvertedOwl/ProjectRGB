using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class ButtonController : MonoBehaviour
{
    public RGBController lCap;
    public RGBController rCap;
    public RGBController bg;
    public void HoverEnter()
    {
        if (lCap)
        {
            lCap.aberrateX = 25;
            lCap.aberrateY = 25;            
        }
        if (rCap)
        {
            rCap.aberrateX = 25;
            rCap.aberrateY = 25;            
        }
        if (bg)
        {
            bg.aberrateX = 25;
            bg.aberrateY = 25;            
        }
    }

    public void OpenFolder()
    {
        String documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String dirPath = Path.Combine(documents, "ProjectRGB_data");
        Directory.CreateDirectory(dirPath);
        Process.Start("explorer.exe", dirPath);
    }

    public void SetPlayerPrefToNothing(String pref)
    {
        String documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String dirPath = Path.Combine(documents, "ProjectRGB_data");
        Directory.CreateDirectory(dirPath);
        String filePath = Path.Combine(dirPath, "lvl_" + Mathf.Floor(UnityEngine.Random.Range(10000, 99999)) + ".json");
        PlayerPrefs.SetString(pref, filePath);
    }
    public void HoverExit()
    {
        if (lCap)
        {
            lCap.aberrateX = 0;
            lCap.aberrateY = 0;            
        }
        if (rCap)
        {
            rCap.aberrateX = 0;
            rCap.aberrateY = 0;            
        }
        if (bg)
        {
            bg.aberrateX = 0;
            bg.aberrateY = 0;            
        }
    }
    

    public void Click()
    {
        GameObject.FindObjectOfType<SoundController>().Play(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
}
