using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    public GameObject smallPin;
    Vector3 positionVector3;
    Vector3 rotationVector3;
    bool fallen = false;
    [SerializeField] int pinPoints = 10;
    [SerializeField] int fallAngle = 45;
    public int pinSpawnQuantity = 10;
    public float explosionForce = 500.0f;
    public float explosionUpForce = 500.0f;
    public float explosionRaidus = 5.0f;
    void Start()
    {
        positionVector3 = transform.position;
        rotationVector3 = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if (!(Vector3.Angle(transform.up, Vector3.up) > fallAngle) || fallen) return;

        fallen = true;
        if (SceneManager.GetActiveScene().name != "GameplayBowling") return;
        GameManager.Get().score += pinPoints;
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
        float mod;
        GameManager.Get().score += pinPoints;
        for (short i = 0; i < pinSpawnQuantity; i++)
        {
            mod = i % 2 == 0 ? 0.5f : -0.5f;
            Instantiate(smallPin, new Vector3(transform.position.x + mod, transform.position.y, transform.position.z),
                Quaternion.identity);
        }
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRaidus);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag == "PinSmall")
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRaidus, explosionUpForce);
        }
        GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRaidus, explosionUpForce);
    }
}