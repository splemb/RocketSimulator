using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] Transform startingBody;
    [SerializeField] LayerMask geometry;

    [SerializeField] Slider thrustSlider;
    [SerializeField] ParticleSystem thrustParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        

        if (startingBody != null)
        {
            Vector3 toBody = startingBody.position - transform.position;
            transform.LookAt(-toBody);

            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.forward, out hit, 10f, geometry))
            {
                transform.position = hit.point + (transform.forward * 0.2f);
            }
            
        }


    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.TransformDirection(0, 0, thrustSlider.value));

        var particleStartLifetime = thrustParticle.main;
        particleStartLifetime.startLifetime = thrustSlider.value * 0.01f;

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(transform.right * Time.deltaTime * 100f, transform.position + transform.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(-transform.right * Time.deltaTime * 100f, transform.position + transform.forward);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForceAtPosition(-transform.up * Time.deltaTime * 100f, transform.position + transform.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(transform.up * Time.deltaTime * 100f, transform.position + transform.forward);
        }
    }
}
