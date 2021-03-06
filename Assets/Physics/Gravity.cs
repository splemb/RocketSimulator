using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 startingVelocity;

    List<Transform> gravitySources = new List<Transform>();

    const double G = 6.67430E-11;
    const float scale = 30000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(startingVelocity, ForceMode.Impulse);
        GetGravitySources();
    }

    void GetGravitySources()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("GravitySource")) {
            //ADD DISTANCE CHECK
            if (g != this.gameObject)
                gravitySources.Add(g.transform);
        }
    }

    void GravityPull()
    {
        foreach (Transform t in gravitySources)
        {

            Vector3 toOrbitCenter = t.position - transform.position;

            double force = G * (t.GetComponent<Rigidbody>().mass * rb.mass / Mathf.Pow(toOrbitCenter.magnitude, 2)) * scale;
            force = Mathf.Clamp((float)force, 0, (float)(G * (t.GetComponent<Rigidbody>().mass * rb.mass / Mathf.Pow(t.transform.localScale.x * 0.5f, 2)) * scale));
            //Debug.Log(force);

            rb.AddForce((toOrbitCenter.normalized * (float)force * Time.deltaTime));
        } 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GravityPull();

        if (Input.GetKey(KeyCode.LeftShift))
            transform.LookAt(transform.position + rb.velocity);
    }
}
