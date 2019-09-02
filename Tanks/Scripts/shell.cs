using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

        if(collider.tag == "Tank")
        {
            collider.SendMessage("TakeDamage");
        }
    }
}