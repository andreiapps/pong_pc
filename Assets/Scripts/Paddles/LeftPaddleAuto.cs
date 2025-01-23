using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleAuto : MonoBehaviour
{

    private float speed = 10;
    private float yBound = 1.9f;
    private GameObject ball;

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    void FixedUpdate()
    {
        if (ball.transform.position.x < 1.52)
        {
            if (transform.position.y < ball.transform.position.y)
            {
                if (transform.position.y < yBound)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
            if (transform.position.y > ball.transform.position.y)
            {
                if (transform.position.y > -yBound)
                {
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}