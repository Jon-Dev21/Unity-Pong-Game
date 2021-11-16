using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Score for player 1
    private int scorePlayer1 = 0;
    
    // Score for player 2
    private int scorePlayer2 = 0;

    // TextScore for player 1
    public GameObject scoreTextPlayer1;

    // TextScore for player 2
    public GameObject scoreTextPlayer2;

    // Integer that indicates how much score is needed to win the game.
    public int goalToWin;

    /// <summary>
    /// Update is called once per frame.
    /// We want to check if either player won.
    /// </summary>
    void Update()
    {
        if(scorePlayer1 >= goalToWin)
        {
            PlayerPrefs.SetString("Winner", "Player 1 Wins");
            SceneManager.LoadScene("GameOver");
            scorePlayer1 = 0;
            scorePlayer2 = 0;
        } else if(scorePlayer2 >= goalToWin)
        {
            PlayerPrefs.SetString("Winner", "Player 2 Wins");
            SceneManager.LoadScene("GameOver");
            scorePlayer1 = 0;
            scorePlayer2 = 0;
        }
    }

    /// <summary>
    /// Update Scores in UI.
    /// </summary>
    private void FixedUpdate()
    {
        // Access the Player1 score text.
        Text uiScoreP1 = scoreTextPlayer1.GetComponent<Text>(); // scoreTextPlayer1 is passed from the Unity Editor score text for player 1
        uiScoreP1.text = scorePlayer1.ToString();

        // Access the Player2 score text.
        Text uiScoreP2 = scoreTextPlayer2.GetComponent<Text>(); // scoreTextPlayer2 is passed from the Unity Editor score text for player 2
        uiScoreP2.text = scorePlayer2.ToString();
    }

    /// <summary>
    /// Increment player1 score when player 1 gets a goal
    /// Method is public so that it can be called from other scripts
    /// </summary>
    public void GoalPlayer1()
    {
        scorePlayer1++;
    }

    /// <summary>
    /// Increment player2 score when player 2 gets a goal.
    /// Method is public so that it can be called from other scripts
    /// </summary>
    public void GoalPlayer2()
    {
        scorePlayer2++;
    }

    /// <summary>
    /// Returns the game winner.
    /// </summary>
    /// <returns></returns>
}
