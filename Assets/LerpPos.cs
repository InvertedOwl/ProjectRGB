using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class LerpPos : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 _currentPos;
    public float speed = 0.01f;
    
    void Update()
    {
        _currentPos = Vector3.Lerp(_currentPos, targetPos, Time.deltaTime * 10);
        transform.position = _currentPos;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            targetPos += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            targetPos += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetPos += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            targetPos += new Vector3(0, -speed, 0);
        }
    }
}
