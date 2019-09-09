using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public AudioClip musicPickup;

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == Tags.player)
        {
            Player player = other.GetComponent<Player>();
            player.hasKey = true;
            AudioSource.PlayClipAtPoint(musicPickup, transform.position);
            Destroy(gameObject);
        }
    }
}
