﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBees : MonoBehaviour
{
    public float rotationspeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationspeed, 0),Space.Self);
    }
}