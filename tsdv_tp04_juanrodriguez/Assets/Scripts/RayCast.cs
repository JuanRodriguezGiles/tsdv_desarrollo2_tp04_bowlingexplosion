using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayCast : MonoBehaviour
{
    Camera mainCamera;
    private float maxDistance = 50;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.yellow);

        if (!Input.GetMouseButtonDown(0)) return;

        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, maxDistance)) return;

        if (hit.collider.gameObject.tag == "Pin")
            hit.collider.gameObject.GetComponent<Pin>().ExplodePin();
        else if (hit.collider.gameObject.tag != "PinSmall")
            GameManager.Get().LoadScoreScreenScene();
    }
}
