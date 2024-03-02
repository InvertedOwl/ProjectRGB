using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public RGBController lCap;
    public RGBController rCap;
    public RGBController bg;
    public void HoverEnter()
    {
        lCap.aberrateX = 25;
        lCap.aberrateY = 25;
        rCap.aberrateX = 25;
        rCap.aberrateY = 25;
        bg.aberrateX = 25;
        bg.aberrateY = 25;
    }
    public void HoverExit()
    {
        lCap.aberrateX = 0;
        lCap.aberrateY = 0;
        rCap.aberrateX = 0;
        rCap.aberrateY = 0;
        bg.aberrateX = 0;
        bg.aberrateY = 0;
    }
}