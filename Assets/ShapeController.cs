using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeController : MonoBehaviour
{
    public float targetRotation;
    private float _currentRotation;
    public Vector3 targetPosition;
    private Vector3 _currentPosition;
    public RGBController aberration;
    public float rotSpeed = 2;
    public float posSpeed = 2;
    public Vector3 initialPosition;

    private void Start()
    {
        targetPosition = transform.position;
        _currentPosition = targetPosition;
        initialPosition = targetPosition;
        targetRotation = transform.eulerAngles.z;
        _currentRotation = targetRotation;
    }

    void Update()
    {
        _currentRotation = Mathf.Lerp(_currentRotation, targetRotation, Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(0, 0, _currentRotation);
        
        _currentPosition = Vector3.Lerp(_currentPosition, targetPosition, Time.deltaTime * posSpeed);
        transform.position = _currentPosition;
    }
}
