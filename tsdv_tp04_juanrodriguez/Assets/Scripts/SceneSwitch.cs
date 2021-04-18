using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{
    public void LoadBowlingGameplayScene()
    {
        GameManager.Get().LoadBowlingGameplayScene();
    }
    public void LoadGunGameplayScene()
    {
        GameManager.Get().LoadGunGameplayScene();
    }
    public void LoadScoreScreenScene()
    {
        GameManager.Get().LoadScoreScreenScene();
    }
    public void LoadCreditsScene()
    {
        GameManager.Get().LoadCreditsScene();
    }
    public void LoadMainMenuScene()
    {
        GameManager.Get().LoadMainMenuScene();
    }
}
