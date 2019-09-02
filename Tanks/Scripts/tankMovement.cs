using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankMovement : MonoBehaviour
{
    public float speed = 5;
    public float angularSpeed = 2;
    public float number = 1;   //玩家的编号
    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical" + number);
        rigidbody.velocity = transform.forward * v * speed;
        float h = Input.GetAxis("Horizontal" + number);
        rigidbody.angularVelocity = transform.up * h * angularSpeed;

        if(Mathf.Abs(h) > 0.1||Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if (!audio.isPlaying)
                audio.Play();
        }
        else
        {
            audio.clip = idleAudio;
            if (!audio.isPlaying)
                audio.Play();
        }
    }
}
