using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleManualPC : MonoBehaviour
{

    private float speed = 10;
    private float yBound = 1.9f;

    void FixedUpdate()
    {
		// Move paddle according to pressed key and make sure it doesn't get out of screen
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < yBound)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -yBound)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
    }
}
