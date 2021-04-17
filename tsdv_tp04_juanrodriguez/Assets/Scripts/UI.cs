using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI : MonoBehaviour
{
    public GameObject ball;
    private Ball ballScript;
    public GameObject gameStatus;
    private GameStatus gameStatusScript;
    public TMP_Text force;
    public TMP_Text pinsLeft;
    public TMP_Text shotsLeft;
    public TMP_Text gameOver;
    public TMP_Text score;
    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
        gameStatusScript = gameStatus.GetComponent<GameStatus>();
    }
    void Update()
    {
        shotsLeft.text = "Shots Left: " + gameStatusScript.shotsLeft.ToString();
        pinsLeft.text = "Pins Left: " + gameStatusScript.pinsLeft.ToString();
        force.text = "Force: " + Mathf.Round(ballScript.force).ToString();
        score.text = "Score: " + gameStatusScript.score.ToString();
        if (!gameStatusScript.playing)
        {
            if (gameStatusScript.pinsLeft > 0)
                gameOver.text = "You lost!";
            else
                gameOver.text = "You won!";
        }
    }
}
