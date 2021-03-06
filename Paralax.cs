﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, startpos;
    public GameObject Cam;
    public float ParallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        float temp = Cam.transform.position.x *(1 -ParallaxEffect);
        float dist = Cam.transform.position.x * ParallaxEffect;
        
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }

        else if (temp < startpos - length)
        {
            startpos -= length;
        }

    }
}
