﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{
    public float lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
