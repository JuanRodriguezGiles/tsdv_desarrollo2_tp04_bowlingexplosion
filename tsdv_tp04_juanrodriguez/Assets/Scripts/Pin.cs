using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pin : MonoBehaviour
{
    Vector3 positionVector3;
    Vector3 rotationVector3;
    bool fallen = false;
    [SerializeField] int pinPoints = 10;
    [SerializeField] int fallAngle = 45;
    void Start()
    {
        positionVector3 = transform.position;
        rotationVector3 = transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (!(Vector3.Angle(transform.up, Vector3.up) > fallAngle) || fallen) return;

        fallen = true;
        GameManager.Get().score += pinPoints;
    }
    public void ResetPin()
    {
        transform.position = positionVector3;
        transform.rotation.eulerAngles.Set(rotationVector3.x, rotationVector3.y, rotationVector3.z);
    }
    public void DestroyPin()
    {
        if (fallen)
            Destroy(gameObject);
    }
}