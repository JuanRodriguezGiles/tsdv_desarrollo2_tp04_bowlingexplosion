using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PinManager : MonoBehaviour
{
    public GameObject ball;
    private Ball ballScript;
    public List<GameObject> pins;

    private static PinManager instance;
    public static PinManager Get()
    {
        return instance;
    }
    void Start()
    {
        instance = this;
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
                newPosVector3.x = Random.Range(-2f, 2f);
                newPosVector3.y = 1.2f;
                newPosVector3.z = Random.Range(0, 30);
            } while (!IsPosValid(newPosVector3));

            t.transform.position = newPosVector3;
        }
    }
    bool IsPosValid(Vector3 pos)
    {
        foreach (GameObject pin in pins)
        {
            if (pos.x >= pin.transform.position.x - 0.5f && pos.x <= pin.transform.position.x + 0.5f && pos.z >= pin.transform.position.z - 0.5f &&
                pos.z <= pin.transform.position.z + 0.5f)
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