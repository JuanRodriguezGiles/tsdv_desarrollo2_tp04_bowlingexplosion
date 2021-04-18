using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PinManager : MonoBehaviour
{
    GameObject ball;
    Ball ballScript;
    List<GameObject> pins;
    [SerializeField] Vector3 randomRange = new Vector3(2.0f, 1.2f, 30.0f);
    [SerializeField] float distBetweenPins = 0.5f;

    private static PinManager instance;
    public static PinManager Get()
    {
        return instance;
    }
    void Start()
    {
        instance = this;
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballScript = ball.GetComponent<Ball>();
        pins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pin"));
    }
    void Update()
    {
        if (ballScript.rolling || !Input.GetKeyDown(KeyCode.P)) return;

        foreach (var t in pins)
        {
            Vector3 newPosVector3;
            do
            {
                newPosVector3.x = Random.Range(-randomRange.x, randomRange.x);
                newPosVector3.y = randomRange.y;
                newPosVector3.z = Random.Range(0, randomRange.z);
            } while (!IsPosValid(newPosVector3));

            t.transform.position = newPosVector3;
        }
    }
    bool IsPosValid(Vector3 pos)
    {
        foreach (GameObject pin in pins)
        {
            if (pos.x >= pin.transform.position.x - distBetweenPins && pos.x <= pin.transform.position.x + distBetweenPins && pos.z >= pin.transform.position.z - distBetweenPins &&
                pos.z <= pin.transform.position.z + distBetweenPins)
                return false;
        }
        return true;
    }
    void ResetPins()
    {
        foreach (GameObject pin in pins)
        {
            pin.GetComponent<Pin>().ResetPin();
        }
    }
    public void DestroyPins()
    {
        foreach (GameObject pin in pins)
        {
            pin.GetComponent<Pin>().DestroyPin();
        }
    }
}