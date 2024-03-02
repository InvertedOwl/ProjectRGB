using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AberrationGate : MonoBehaviour
{
    private RGBController _controller;
    private float _redSpeed = 1;
    private float _greenSpeed = 1.5f;
    private float _blueSpeed = 0.5f;
    void Start()
    {
        _controller = GetComponent<RGBController>();
    }

    // Update is called once per frame
    void Update()
    {
        _controller.red.transform.eulerAngles += new Vector3(0, 0, _redSpeed);
        _controller.green.transform.eulerAngles += new Vector3(0, 0, _greenSpeed);
        _controller.blue.transform.eulerAngles += new Vector3(0, 0, _blueSpeed);

        _redSpeed += UnityEngine.Random.Range(-0.05f, 0.05f);
        _greenSpeed += UnityEngine.Random.Range(-0.05f, 0.05f);
        _blueSpeed += UnityEngine.Random.Range(-0.05f, 0.05f);
    }
}
