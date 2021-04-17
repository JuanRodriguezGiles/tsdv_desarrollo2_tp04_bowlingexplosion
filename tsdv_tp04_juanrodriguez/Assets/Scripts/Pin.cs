using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : MonoBehaviour
{
    private Vector3 positionVector3;
    private Vector3 rotationVector3;
    public bool fallen = false;
    void Start()
    {
        positionVector3 = transform.position;
        rotationVector3 = transform.rotation.eulerAngles;
    }
    void Update()
    {//
        if(fallen)
            Destroy(gameObject);
    }
    void resetPin()
    {
        transform.position = positionVector3;
        transform.rotation.eulerAngles.Set(rotationVector3.x, rotationVector3.y, rotationVector3.z);
    }
}