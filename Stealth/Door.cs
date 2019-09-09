using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool requireKey = false;

    private int count = 0;
    private Animator anim;
    private AudioSource audio;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        anim.SetBool("Close", count <= 0);
        if (anim.IsInTransition(0))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (requireKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.hasKey)
                {
                    count++;
                }
            }
        }
        else
        {
            if (other.tag == Tags.player)
            {
                count++;
            }else if(other.tag == Tags.enemy && other.GetComponent<Collider>().isTrigger == false)
            {
                count++;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (requireKey)
        {
            if (other.tag == Tags.player)
            {
                Player player = other.GetComponent<Player>();
                if (player.hasKey)
                {
                    count--;
                }
            }
        }
        else
        {
            if (other.tag == Tags.player)
            {
                count--;
            }
            else if (other.tag == Tags.enemy && other.GetComponent<Collider>().isTrigger == false)
            {
                count--;
            }
        }
    }
}
