using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 recordedOrbitPosition;
    public int orbits;
    public bool recording;

    public TMPro.TextMeshProUGUI orbitCounter;

    [SerializeField] Transform startingBody;
    [SerializeField] LayerMask geometry;

    [SerializeField] Slider thrustSlider;
    [SerializeField] ParticleSystem thrustParticle;

    [SerializeField] bool launchState = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;
        

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

    private void Update()
    {
        if (recording && (recordedOrbitPosition - transform.position).magnitude < 1f)
        {
            orbits++;
            orbitCounter.text = orbits.ToString();
            recording = false;
            StartCoroutine(WaitToRecord());
        }

        if (Input.GetKeyDown(KeyCode.Space)) Launch();
    }

    public void Launch()
    {
        launchState = false;
        rb.isKinematic = false;
        GetComponent<Gravity>().enabled = true;
    }

    IEnumerator WaitToRecord()
    {
        yield return new WaitForSeconds(5);
        recording = true;
        yield return 0;
    }

    public void SetOrbitPosition()
    {
        orbits = 0;
        orbitCounter.text = "0";
        recording = false;
        recordedOrbitPosition = transform.position;
        StartCoroutine(WaitToRecord());
    }

    private void FixedUpdate()
    {
        if (!launchState)
        {
            rb.AddForce(transform.TransformDirection(0, 0, thrustSlider.value));

            

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

        } else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -100f * Time.deltaTime);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, 100f * Time.deltaTime);
            }

            
        }

        var particleStartLifetime = thrustParticle.main;
        particleStartLifetime.startLifetime = thrustSlider.value * 0.01f;


    }
}
