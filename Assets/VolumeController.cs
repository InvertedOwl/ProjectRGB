using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public SliderController slider;
    public TMP_Text text;

    void Update()
    {
        text.text = "Volume: " + Mathf.Round(slider.progress * 100);
        AudioListener.volume = slider.progress;
    }
}
