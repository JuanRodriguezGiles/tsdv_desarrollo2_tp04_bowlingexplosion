using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    [SerializeField] int points;
    private static GameManagerTest instance;
    public static GameManagerTest Get()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    public void AddScore(int score)
    {
        points += score;
    }
}