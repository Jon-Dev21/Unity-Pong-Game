using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the ball movement for the Pong ball
/// </summary>
public class BallMovement : MonoBehaviour
{
    // Creating public variable so that we can change the speed.
    public float movementSpeed;

    // Number by which the speed will increment with every hit.
    public float extraSpeedPerHit;

    // Variable to indicate the maximum speed the ball can have.
    public float maxExtraSpeed;

    // Counts how many times the ball has been hit.
    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine.
        StartCoroutine(StartBall());
    }

    /// <summary>
    /// Creating an IEnumerator co-routine (Forces everything else to wait for it before new actions happen).
    /// This way we can control that one routine waits for another.
    /// </summary>
    /// <param name="isStartingPlayer1"></param>
    /// <returns></returns>
    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        // Repositioning ball to player's side.
        RepositionBall(isStartingPlayer1);

        // Reset the hit counter to 0.
        hitCounter = 0;
        // Make game wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Then, we start the movement.
        if(isStartingPlayer1)
            MoveBall(new Vector2(-1, 0));
        else
            MoveBall(new Vector2(1, 0));
    }

    /// <summary>
    /// This method will calculate the direction and move the ball in that direction.
    /// </summary>
    /// <param name="direction"></param>
    public void MoveBall(Vector2 direction)
    {
        // Direction has to be a normalized direction.
        direction = direction.normalized; // Will return the vector with a magnitude of 1.

        // Calculate the speed per each hit.
        float speed = movementSpeed + hitCounter * extraSpeedPerHit;

        // Add force to the rigid body.
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        // Calculate the velocity. (direction * speed)
        rigidbody2D.velocity = direction * speed;

    }

    /// <summary>
    /// This method increases the hit counter. 
    /// </summary>
    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeedPerHit <= maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    /// <summary>
    /// This method repositions the ball in the field section 
    /// of the player who got scored on.
    /// </summary>
    public void RepositionBall(bool isStartingPlayer1)
    {
        // Reset the ball's velocity to 0.
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // If player 1 starts,
        if (isStartingPlayer1)
        {
            // Reposition the ball to Player 1's starting point.
            gameObject.transform.localPosition = new Vector3(-90, 0, 0);
        } else
        {
            // Reposition the ball to Player 2's starting point.
            gameObject.transform.localPosition = new Vector3(55, 0, 0);
        }
    }

}
