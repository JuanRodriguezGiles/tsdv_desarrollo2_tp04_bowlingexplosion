using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public float force = 0f;
    public bool rolling = false;
    public bool fallen = false;
    Vector3 positionVector3;
    Vector3 rotationVector3;
    float maxSideMovement = 2.0f;
    [SerializeField] float forceNormalizer = 50.0f;
    void Start()
    {
        positionVector3 = transform.position;
        rotationVector3 = transform.rotation.eulerAngles;
        GameManager.Get().GetBallGameObject();
    }
    void Update()
    {
        if (rolling) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolling = true;
            GetComponent<ConstantForce>().force = new Vector3(0, 0, force);
            GameManager.Get().shotsLeft--;
            return;
        }

        float hor = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(hor, 0, 0);
        transform.position += direction * Time.deltaTime;
        if (transform.position.x <= -maxSideMovement)
            transform.position = new Vector3(-maxSideMovement, transform.position.y, transform.position.z);
        if (transform.position.x >= maxSideMovement)
            transform.position = new Vector3(maxSideMovement, transform.position.y, transform.position.z);

        force += Input.GetAxis("Vertical") / forceNormalizer;
        if (force < 0)
            force = 0;
    }
    public void ResetBall()
    {
        GetComponent<ConstantForce>().force = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = positionVector3;
        transform.rotation.eulerAngles.Set(rotationVector3.x, rotationVector3.y, rotationVector3.z);
        rolling = false;
        force = 0;
    }
}
