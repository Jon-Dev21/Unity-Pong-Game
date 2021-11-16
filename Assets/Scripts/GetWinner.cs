using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script gets the winner from the ScoreController Object.
/// </summary>
public class GetWinner : MonoBehaviour
{
    public Text winnerText;
    // Update is called once per frame
    void Start()
    {
        winnerText.text = PlayerPrefs.GetString("Winner");
    }
}
