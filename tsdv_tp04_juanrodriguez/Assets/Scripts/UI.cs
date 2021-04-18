using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UI : MonoBehaviour
{
    GameObject ball;
    Ball ballScript;
    public TMP_Text force;
    public TMP_Text pinsLeft;
    public TMP_Text shotsLeft;
    public TMP_Text score;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballScript = ball.GetComponent<Ball>();
    }
    void Update()
    {
        shotsLeft.text = "Shots Left: " + GameManager.Get().shotsLeft.ToString();
        pinsLeft.text = "Pins Left: " + GameManager.Get().pinsLeft.ToString();
        force.text = "Force: " + Mathf.Round(ballScript.force);
        score.text = "Score: " + GameManager.Get().score.ToString();
    }
}
