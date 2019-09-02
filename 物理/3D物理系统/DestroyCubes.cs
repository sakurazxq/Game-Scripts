using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube")
        {
            Destroy(col.gameObject);
        }
    }
}
