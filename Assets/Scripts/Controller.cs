using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 10;
    public float jumpHeight = 10;
    private bool _onGround;
    public float ySquish = 5;
    private Rigidbody2D rb2;
    public bool controllsEnabled = true;

    void Start() {
        rb2 = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _onGround) && controllsEnabled) {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpHeight);
            _onGround = false;
        }
    }

    private bool _reportedDead = false;
    
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && controllsEnabled) {
            rb2.velocity += (new Vector2(-1 * speed , 0));
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && controllsEnabled) {
            rb2.velocity += (new Vector2(1 * speed, 0));
        }

        //Mathf.Pow(rb2.velocity.y/maxSpeed, 3)
        Vector3 scale =
            new Vector3(
                (1 + Mathf.Pow(Math.Abs(rb2.velocity.x / maxSpeed), 3)) -
                Math.Abs(rb2.velocity.y / (maxSpeed * ySquish)),
                1.0f - Mathf.Pow(Math.Abs(rb2.velocity.x / (maxSpeed)), 3));
        this.transform.GetChild(0).GetChild(1).localScale = scale;
        this.transform.GetChild(1).GetChild(1).localScale = scale;
        this.transform.GetChild(2).GetChild(1).localScale = scale;

        this.transform.GetChild(0).GetChild(1).transform.localPosition = new Vector3(0, -(1 - (scale.y * 1))/2);
        this.transform.GetChild(1).GetChild(1).transform.localPosition = new Vector3(0, -(1 - (scale.y * 1))/2);
        this.transform.GetChild(2).GetChild(1).transform.localPosition = new Vector3(0, -(1 - (scale.y * 1))/2);

        if (!(transform.GetChild(0).gameObject.transform.localScale.x > 0.5f) &&
            !(transform.GetChild(1).gameObject.transform.localScale.x > 0.5f) && 
            !(transform.GetChild(2).gameObject.transform.localScale.x > 0.5f))
        {
            rb2.bodyType = RigidbodyType2D.Static;

            if (!_reportedDead)
            {
                Debug.Log("Player died " + _reportedDead);
                StartCoroutine(GameObject.FindObjectOfType<LevelController>().LoadLevelWait(GameObject.FindObjectOfType<LevelController>().currentLevel));
                _reportedDead = true;   
            }
        }
        else
        {
            _reportedDead = false;
            rb2.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Death"))
            _onGround = true;
    }
}
