using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public GameObject gameStatus;
    private GameStatus gameStatusScript;
    public float force = 0f;
    public bool rolling = false;
    private Vector3 positionVector3;
    private Vector3 rotationVector3;
    void Start()
    {
        gameStatusScript = gameStatus.GetComponent<GameStatus>();
        positionVector3 = transform.position;
        rotationVector3 = transform.rotation.eulerAngles;
    }
    void Update()
    {
        if (!rolling && gameStatusScript.playing) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rolling = true;
                GetComponent<ConstantForce>().force = new Vector3(0, 0, force);
                gameStatusScript.shotsLeft--;
                return;
            }

            float hor = Input.GetAxis("Horizontal");
            Vector3 direction = new Vector3(hor, 0, 0);
            transform.position += direction * Time.deltaTime;
            if (transform.position.x <= -2f)
                transform.position = new Vector3(-2, transform.position.y, transform.position.z);
            if (transform.position.x >= 2f)
                transform.position = new Vector3(2, transform.position.y, transform.position.z);

            force += Input.GetAxis("Vertical") / 50;
            if (force < 0)
                force = 0;
        }
    }
    public void resetBall()
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
