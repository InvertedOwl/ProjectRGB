using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBController : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    [Header("Settings")]
    public float aberrateX;
    public float aberrateY;
    public bool useLerp = true;
    private float _lerpSpeed = 8f;
    private float _currentAberrateX;
    private float _currentAberrateY;
    public bool acceptGlobalEditing = true;

    public void FixedUpdate() {
        updateRGB(0.01f);        
    }
    public void OnDrawGizmos() {
        if (!Application.isPlaying)
        {
            updateRGB(0.01f);
        }
    }

    public void updateRGB(float delta) {
        if (useLerp) {
            _currentAberrateX = Mathf.Lerp(_currentAberrateX, aberrateX, delta * _lerpSpeed);
            _currentAberrateY = Mathf.Lerp(_currentAberrateY, aberrateY, delta * _lerpSpeed);
        } else {
            _currentAberrateX = aberrateX;
            _currentAberrateY = aberrateY;
        }

        if (red) {
            red.transform.position = transform.position + new Vector3(-_currentAberrateX, -_currentAberrateY);
        }  
        if (blue) {
            blue.transform.position = transform.position + new Vector3(_currentAberrateX, _currentAberrateY);
        }     
        if (green) {
            green.transform.position = transform.position + new Vector3(0, 0);
        } 
    }
}
