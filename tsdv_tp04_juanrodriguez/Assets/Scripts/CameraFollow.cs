using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset = new Vector3(0, 1.53f, -2.66f);
    public float maxFollowDistance = 20.0f;
    void LateUpdate()
    {
        if (ball.position.z < maxFollowDistance)
            transform.position = ball.position + offset;
    }
}