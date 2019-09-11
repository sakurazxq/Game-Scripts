using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    //public float smoothTime = 0.3f;
    //private Vector3 velocity = Vector3.zero;
    private Vector3 offset = Vector3.zero;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }

    /*void Update()
    {   //逐渐将向量变到期望的位置
        transform.position = Vector3.SmoothDamp(transform.position,player.position,ref velocity,smoothTime);
    }*/
}
