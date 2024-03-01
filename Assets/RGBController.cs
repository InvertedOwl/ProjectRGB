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
    public float lerpSpeed = 4;
    private float _currentAberrateX;
    private float _currentAberrateY;

    public void FixedUpdate() {
        updateRGB(Time.fixedDeltaTime);        
    }
    public void OnDrawGizmos() {
        updateRGB(0.1f);
    }

    public void updateRGB(float delta) {
        if (useLerp) {
            _currentAberrateX = Mathf.Lerp(_currentAberrateX, aberrateX, delta * lerpSpeed);
            _currentAberrateY = Mathf.Lerp(_currentAberrateY, aberrateY, delta * lerpSpeed);
            // Debug.Log(_currentAberrateX + ",x " + aberrateX);
            // Debug.Log(_currentAberrateY + ",y " + aberrateY);
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
