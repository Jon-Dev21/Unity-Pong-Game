using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for an AI player
public class RacketAIPlayer : MonoBehaviour
{
    // Movement speed for the racket
    public float movementSpeed;

    // Ball Object
    public GameObject ball;

    private void FixedUpdate()
    {
        // If the absolute value of the substraction of the position of the racket minus the ball (racket.pos.y - ball.pos.y)
        // is greater than 50, (If the ball is above the origin (0,0)
        // If the ball is further than 50 dots higher, move the racket near the ball.
        if(Mathf.Abs(transform.position.y - ball.transform.position.y) > 30)
        {
            // If the ball is higher than the racket, move it up
            if(transform.position.y < ball.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
            }
            else // If the ball is lower than the racket, move it down
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
            }
        } else // Don't move the racket at all
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) * movementSpeed;
        }
    }
}
