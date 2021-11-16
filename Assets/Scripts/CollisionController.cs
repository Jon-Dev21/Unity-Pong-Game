using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to manage the complex ball movement.
/// </summary>
public class CollisionController : MonoBehaviour
{

    // Declaring an Object from our BallMovement script. (Used to call the increase hit counter method)
    public BallMovement ballMovement;

    // Declaring an Object from our ScoreController script. (Used to call the increase score methods)
    public ScoreController scoreController;

    /// <summary>
    /// This method calculates the new direction of the ball depending on 
    /// where the ball collisions in the player's rackets.
    /// </summary>
    /// <param name="c"></param>
    void BounceFromRacket(Collision2D c)
    {
        // Vector for the ball position.
        Vector3 ballPosition = transform.position;

        // Vector for the racket position.
        Vector3 racketPosition = c.gameObject.transform.position;

        // Variable to store the height of the racket. (Used to know if we hit the racket at the top or bottom.
        float racketHeight = c.collider.bounds.size.y;

        // If ball bounces off player one, direction vector goes from -x to x
        // If ball bounces off player two, direction vector goes from x to -x

        // Create variable for the x position.
        float x;

        // If the ball hit Player 1's racket
        if (c.gameObject.name == "RacketPlayer1")
            x = 1; // Direction should be positive (Left to right)
        else
            x = -1; // Direction should be negative (Right to left)

        // Calculate the Y value to create a Vector2 (Direction of the ball)
        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        // Calling the IncreaseHitCounter method using our ballMovement Object from the earlier script.
        ballMovement.IncreaseHitCounter();
        
        // Call the moveBall method and pass in the new direction (Vector 2)
        ballMovement.MoveBall(new Vector2(x, y));
    }

    /// <summary>
    /// Co-routine for whenever there is a 2D collision.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the ball hit either racket, calculate the new direction and velocity.
        if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            BounceFromRacket(collision);
        } else if (collision.gameObject.name == "WallLeft")
        {
            // Increase the score of player 2.
            scoreController.GoalPlayer2();

            // Reset ball position to player 1's side(Create a subroutine)
            StartCoroutine(ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "WallRight")
        {
            // Increase the score of player 1.
            scoreController.GoalPlayer1();

            // Reset ball position to player 2's side(Create a subroutine)
            StartCoroutine(ballMovement.StartBall(false));
        }
    }
}
