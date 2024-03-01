using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool _onGround;
    private Rigidbody2D rb2;

    void Start() {
        rb2 = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            Debug.Log("Ello");
            rb2.velocity = new Vector2(-1, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _onGround = true;
    }
}
