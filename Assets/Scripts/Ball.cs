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
		// Launch the ball at the beggining of a point(I can't find the right word for what I want to say but like you know, before the players bounce the ball with the paddles or whatever, my explanation is very bad)
        LaunchBall();
    }

    private void Update()
    {
		// End the game if a player has the score 9
        if (leftScore == 9 || rightScore == 9)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		// Check who won a point
        if (collision.gameObject.CompareTag("Goal"))
        {
			// Not sure if this if is needed but whatever
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
