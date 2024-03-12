using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButtonManager : MonoBehaviour
{
    public GameObject levelButton;
    void Start()
    {
        String documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        String filePath = Path.Combine(documents, "ProjectRGB_data");
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        string[] files = Directory.GetFiles(filePath);
        foreach (string file in files)
        {
            GameObject go = GameObject.Instantiate(levelButton, transform);
            TMP_Text text = go.transform.GetComponentInChildren<TMP_Text>();
            text.text = Path.GetFileName(file);
            go.GetComponent<LevelButton>().fileLocation = file;
            go.transform.SetSiblingIndex(0);
            Debug.Log(Path.GetFileName(file));
        }
    }
}
