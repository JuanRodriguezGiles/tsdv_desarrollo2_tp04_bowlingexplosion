using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            col.gameObject.GetComponent<Ball>().fallen = true;
        }
    }
}
