using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    public float targetScale = 1;
    private float _currentScale = 1;
    public float speed = 2;




    private void FixedUpdate() {
        _currentScale = Mathf.Lerp(_currentScale, targetScale, Time.deltaTime * speed);
        this.transform.localScale = new Vector3(_currentScale, _currentScale, 1);
    }
}
