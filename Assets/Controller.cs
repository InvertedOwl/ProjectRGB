using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10;
    private bool _onGround;
    private Rigidbody2D rb2;

    void Start() {
        rb2 = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rb2.velocity = new Vector2(-1 * speed, rb2.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            rb2.velocity = new Vector2(1 * speed, rb2.velocity.y);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _onGround) {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpHeight);
            _onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _onGround = true;
    }
}
