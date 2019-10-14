using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 PosWorld = transform.parent.localToWorldMatrix.MultiplyPoint(transform.localPosition);

        Debug.Log(PosWorld);

        Vector3 targetPos = target.transform.worldToLocalMatrix.MultiplyPoint(PosWorld);

        Debug.Log(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition
    }
}
