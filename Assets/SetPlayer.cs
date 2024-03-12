using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    public void SetPlayerPref()
    {
        PlayerPrefs.SetString("level", "");
    }
}