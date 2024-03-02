using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - new Vector3(-0.3f, 0, 0), transform.position - new Vector3(0.3f, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(0, -0.3f, 0), transform.position - new Vector3(0, 0.3f, 0));
    }
}
