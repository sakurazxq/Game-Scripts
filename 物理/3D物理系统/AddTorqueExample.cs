using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorqueExample : MonoBehaviour
{
    public float amount = 50f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;

        rb.AddTorque(transform.up * h);
        rb.AddTorque(transform.right * v);
    }
}
