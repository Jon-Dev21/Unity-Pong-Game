using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script moves the player 1 racket.
public class RacketPlayer1 : MonoBehaviour
{
    // Racket speed
    public float movementSpeed;

    /// <summary>
    /// This update method is called a fixed amount of times per seconds. (Not per frame)
    /// </summary>
    private void FixedUpdate()
    {
        // Get the raw vertical input axis.
        float v = Input.GetAxisRaw("Vertical");

        // Get the rigid body component.
        // Change the velocity to a new Vector that moves in y * movement Speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
