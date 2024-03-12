using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    public Color targetColor;
    private Color _currentColor;
    void Start()
    {
        targetColor = GetComponent<Image>().color;
        _currentColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        _currentColor = Color.Lerp(_currentColor, targetColor, Time.deltaTime * 10);
        GetComponent<Image>().color = _currentColor;
    }

    public void SetColor(Color color)
    {
        targetColor = color;
    }

    public void SetColorDark()
    {
        targetColor = new Color(targetColor.r - .50f, targetColor.g - .50f, targetColor.b - .50f);
    }
    public void SetColorLight()
    {
        targetColor = new Color(targetColor.r + .50f, targetColor.g + .50f, targetColor.b + .50f);
    }
}
