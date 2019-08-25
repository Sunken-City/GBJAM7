﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SlimeSquishedGameController;

public class Squished : MonoBehaviour
{
    private bool isSquished; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.localScale = new Vector3(transform.localScale.x, 0.3f, transform.localScale.z);
        ++numOfSquishedSlimes;
    }
}
