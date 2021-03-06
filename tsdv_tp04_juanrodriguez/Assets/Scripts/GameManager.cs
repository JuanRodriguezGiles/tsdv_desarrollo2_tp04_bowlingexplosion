using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    GameObject ballGameObject;
    public int score = 0;
    public int shotsLeft = 3;
    public int pinsLeft = 10;
    double time = 0;
    double timeAtFall = 0;
    [SerializeField] private int resetDelay = 3;
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        time += Time.deltaTime;

        if (SceneManager.GetActiveScene().name != "GameplayBowling") return;

        if (!ballGameObject.GetComponent<Ball>().fallen) return;

        if (timeAtFall == 0)
            timeAtFall = time;

        if (!(time > timeAtFall + resetDelay)) return;

        timeAtFall = 0;
        ballGameObject.GetComponent<Ball>().ResetBall();
        ballGameObject.GetComponent<Ball>().fallen = false;
        PinManager.Get().DestroyPins();
        CheckGameOver();
    }
    public void GetBallGameObject()
    {
        ballGameObject = GameObject.FindGameObjectWithTag("Ball");
    }
    void CheckGameOver()
    {
        if (shotsLeft == 0 || pinsLeft == 0)
            SceneManager.LoadScene("GameOver");
    }
    #region SCENES
    public void LoadBowlingGameplayScene()
    {
        SceneManager.LoadScene("GameplayBowling");
    }
    public void LoadGunGameplayScene()
    {
        SceneManager.LoadScene("GameplayGun");
        shotsLeft = 0;
    }
    public void LoadScoreScreenScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}