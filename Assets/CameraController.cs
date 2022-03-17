using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] float minDistance = 1f;
    [SerializeField] float maxDistance = 20f;

    void LateUpdate()
    {
        float rotationAroundYAxis = 0f;
        float rotationAroundXAxis = 0f;

        if (Input.GetMouseButton(1))
        {
            rotationAroundYAxis = Input.GetAxis("Mouse X") * 18; // camera moves horizontally
            rotationAroundXAxis = -Input.GetAxis("Mouse Y") * 18; // camera moves vertically 
        }

        distanceToTarget += -Input.GetAxis("Mouse ScrollWheel") * (maxDistance - minDistance) / 10f;
        distanceToTarget = Mathf.Clamp(distanceToTarget, minDistance, maxDistance);

        transform.position = target.position;

        transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis, Space.Self);
        transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.Self); // <— This is what makes it work!

        transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }
}