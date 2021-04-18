using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    GameObject ballGameObject;
    public int score;
    bool playing = true;
    int shotsLeft = 3;
    int pinsLeft = 10;
    [SerializeField] double time = 0;
    [SerializeField] double timeAtFall = 0;

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
        time += Time.deltaTime;

        if (SceneManager.GetActiveScene().name != "GameplayBowling") return;

        if (!ballGameObject.GetComponent<Ball>().fallen) return;

        if (timeAtFall == 0)
            timeAtFall = time;

        if (!(time > timeAtFall + 3)) return;

        timeAtFall = 0;
        ballGameObject.GetComponent<Ball>().ResetBall();
        ballGameObject.GetComponent<Ball>().fallen = false;
        PinManager.Get().DestroyPins();
    }
    public void GetBallGameObject()
    {
        ballGameObject = GameObject.FindGameObjectWithTag("Ball");
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