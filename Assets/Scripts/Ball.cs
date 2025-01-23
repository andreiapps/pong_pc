using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public int rightScore, leftScore = 0;

    void LaunchBall()
    {
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        if (GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            while (GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LaunchBall();
    }

    private void Update()
    {
        if (leftScore == 9 || rightScore == 9)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (!(leftScore == 9) || !(rightScore == 9))
            {
                if (collision.gameObject.name == "LeftGoal")
                {
                    rightScore += 1;
                }
                else if (collision.gameObject.name == "RightGoal")
                {
                    leftScore += 1;
                }
                LaunchBall();
            }
        }
    }
}