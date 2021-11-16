using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle playing a sound when racket or the wall is hit.
/// </summary>
public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;
    public AudioSource goalSound;

    /// <summary>
    /// Method evaluates if the ball collisioned with the rackets or the wall.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with the rackets.
        if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            // If racket sound is passed, play the racket sound
            racketSound.Play();
        } else if(collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight")
        {
            // If a collision is detected with the left and right walls.
            // If goal sound is passed, play the goal sound
            goalSound.Play();
        }
        else 
        {
            // If a collision is detected with the top and bottom walls.
            // If wall sound is passed, play the wall sound
            wallSound.Play();
        }
    }


}
