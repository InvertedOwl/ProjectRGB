using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public AberrationController controller;
    public float aberrationLeftX = 2;
    public float aberrationLeftY = 2;
    public float aberrationRightX = 2;
    public float aberrationRightY = 2;

    private float ticksToWait = 0;
    private void OnTriggerStay2D(Collider2D other) {
        Gate(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Gate(other);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Gate(other);
        Debug.Log("Enter");
    }

    private void Gate(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ticksToWait == 0)
            {
                Debug.Log("Entered Aberrator");
                if (other.GetComponentInParent<Rigidbody2D>().velocity.x > 0)
                {
                    controller.aberrationX = aberrationLeftX;
                    controller.aberrationY = aberrationLeftY;
                    ticksToWait += 0;
                }
                else
                {
                    controller.aberrationX = aberrationRightX;
                    controller.aberrationY = aberrationRightY;
                    ticksToWait += 0;
                }
            }            
        }
    }
    
    public void Start()
    {
        transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        ticksToWait -= 1;
        ticksToWait = Mathf.Max(0, ticksToWait); 
    }
}
