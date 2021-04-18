using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunGameplayUI : MonoBehaviour
{
    public TMP_Text score;
    void Start()
    {
        
    }
    void Update()
    {
        score.text = "Score: " + GameManager.Get().score.ToString();
    }
}
