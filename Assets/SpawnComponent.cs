using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    public GameObject component;
    public Camera cam;

    public void SpawnComp()
    {
        GameObject g = Instantiate(component);
        g.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
    }
}
