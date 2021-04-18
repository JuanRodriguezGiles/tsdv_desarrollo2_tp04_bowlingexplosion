using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    Vector3 positionVector3;
    Vector3 rotationVector3;
    bool fallen = false;
    [SerializeField] int pinPoints = 10;
    [SerializeField] int fallAngle = 45;
    public float yForce = 1.0f;
    public int pinSpawnQuantity = 10;
    public GameObject smallPin;
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

        if (SceneManager.GetActiveScene().name != "GameplayBowling") return;
        GameManager.Get().pinsLeft--;
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
    public void ExplodePin()
    {
        GameManager.Get().score += pinPoints;
        GetComponent<Rigidbody>().velocity = new Vector3(0, yForce, 0);
        for (short i = 0; i < pinSpawnQuantity; i++)
            Instantiate(smallPin, transform.position, Quaternion.identity);
    }
}