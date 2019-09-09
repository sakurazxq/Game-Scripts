using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool isFlicker = false;

    public float onTime = 3;
    public float offTime = 3;
    private float timer = 0;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isFlicker)
        {
            timer += Time.deltaTime;
            if (renderer.enabled)
            {
                if(timer >= onTime)
                {
                    renderer.enabled = false;
                    timer = 0;
                }
            }
            if (!renderer.enabled)
            {
                if (timer >= offTime)
                {
                    renderer.enabled = true;
                    timer = 0;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.player)
        {
            GameController._instance.SeePlayer(other.transform);
        }
    }
}
