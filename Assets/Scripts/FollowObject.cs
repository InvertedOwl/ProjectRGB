using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform follow;
    public Vector3 offset;
    public float speed;
    private Vector3 _current;

    // Update is called once per frame
    void Update()
    {
        _current = Vector3.Lerp(_current, follow.position + offset, Time.deltaTime * speed);
        transform.position = _current + new Vector3(0, 0, -10);        
    }

    public void SetToPos(Vector3 pos)
    {
        _current = pos;
    }
}
