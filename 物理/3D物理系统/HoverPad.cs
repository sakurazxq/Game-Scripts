using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPad : MonoBehaviour
{
    public float hoverForce;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered the trigger");
    }

    void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * hoverForce, ForceMode.Acceleration);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object exited the trigger");
    }
}
