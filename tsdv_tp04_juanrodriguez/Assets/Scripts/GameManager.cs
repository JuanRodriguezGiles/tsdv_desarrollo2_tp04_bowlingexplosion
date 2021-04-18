using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score;
    bool playing = true;
    int shotsLeft = 3;
    int pinsLeft = 10;

    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

    }
    #region SCENES
    public void LoadBowlingGameplayScene()
    {
        SceneManager.LoadScene("GameplayBowling");
    }
    public void LoadGunGameplayScene()
    {
        SceneManager.LoadScene("GameplayGun");
    }
    public void LoadScoreScreenScene()
    {
        SceneManager.LoadScene("ScoreScreen");
    }
    public void LoadCreditsSCene()
    {
        SceneManager.LoadScene("Credits");
    }
    #endregion
}