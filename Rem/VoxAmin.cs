using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxAmin : MonoBehaviour
{
    public AnimationCurve ac;
    Vector3 s;
    public float playSpeed = 3f;
    private float timeOffet = 0;

    // Start is called before the first frame update
    void Start()
    {
        s = transform.localScale;
        timeOffet = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        timeOffet += Time.deltaTime;
        float r = ac.Evaluate(timeOffet *  playSpeed);
        transform.localScale = new Vector3(s.x, s.y * r, s.z);
    }
}
