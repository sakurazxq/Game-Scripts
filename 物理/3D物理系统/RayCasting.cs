using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    public float distance;

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * distance);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
