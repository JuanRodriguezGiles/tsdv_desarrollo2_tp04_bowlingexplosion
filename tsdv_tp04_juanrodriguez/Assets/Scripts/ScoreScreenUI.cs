using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ScoreScreenUI : MonoBehaviour
{
    public TMP_Text gameOverMessage;
    public TMP_Text score;
    void Start()
    {
        score.text = "Score: " + GameManager.Get().score.ToString();
        gameOverMessage.text = GameManager.Get().pinsLeft == 0 ? "You won!" : "You lost!";
    }
}