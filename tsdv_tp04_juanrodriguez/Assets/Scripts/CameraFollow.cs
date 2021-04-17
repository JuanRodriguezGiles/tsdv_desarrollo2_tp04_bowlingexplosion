using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset = new Vector3(0, 1.53f, -2.66f);
    void LateUpdate()
    {
        if (ball.position.z < 20)
            transform.position = ball.position + offset;
    }
}