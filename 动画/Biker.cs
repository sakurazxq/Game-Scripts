﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biker : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        anim.SetInteger("Vertical", (int)v);
        //transform.Translate(Vector3.forward * v * Time.deltaTime * 4);
    }
}
