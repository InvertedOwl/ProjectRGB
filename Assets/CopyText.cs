using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CopyText : MonoBehaviour
{
    public List<TMP_Text> texts;
    private TMP_Text currentText;
    private void Start()
    {
        currentText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        foreach (TMP_Text text in texts)
        {
            text.text = currentText.text;
        }
    }
}
