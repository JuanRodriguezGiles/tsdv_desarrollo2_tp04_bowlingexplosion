using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameStatus : MonoBehaviour
{
    public GameObject ball;
    private Ball ballScript;
    public bool playing = true;
    public int shotsLeft = 3;
    public int pinsLeft = 10;
    public int score = 0;
    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
    }
    void Update()
    {
        if ((shotsLeft == 0 || pinsLeft == 0) && !ballScript.rolling) 
            playing = false;
    }
}
