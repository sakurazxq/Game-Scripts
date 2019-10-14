using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    public float rotateSpeed = 7;
    public bool hasKey = false;
    public GameObject ButtonUp;
    public GameObject ButtonDown;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    private Animator anim;
    private AudioSource audio;
    private float h = 0;
    private float v = 0;
    private OnButtonPressed Up;
    private OnButtonPressed Down;
    private OnButtonPressed Right;
    private OnButtonPressed Left;


    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Up = ButtonUp.GetComponent<OnButtonPressed>();
        Down = ButtonDown.GetComponent<OnButtonPressed>();
        Right = ButtonRight.GetComponent<OnButtonPressed>();
        Left = ButtonLeft.GetComponent<OnButtonPressed>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Sneak",true);
        }
        else
        {
            anim.SetBool("Sneak", false);
        }
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");


        if (Up.isDown && !Down.isDown)
        {
            v = 1.0f;
        }
        else if (!Up.isDown && Down.isDown)
        {
            v = -1.0f;
        }
        else { v = 0; }

        if (Right.isDown&&!Left.isDown)
        {
            h = 1.0f;
        }else if(!Right.isDown && Left.isDown)
        {
            h = -1.0f;
        }
        else { h = 0; }

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            float newSpeed = Mathf.Lerp(anim.GetFloat("Speed"), 5.6f, moveSpeed * Time.deltaTime);
            anim.SetFloat("Speed", newSpeed);

            Vector3 targetDir = new Vector3(h, 0, v);
            Quaternion newRotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
        {
            PlayFootMusic();
        }
        else
        {
            StopFootMusic();
        }
    }


    private void PlayFootMusic()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }       
    }
    private void StopFootMusic()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
