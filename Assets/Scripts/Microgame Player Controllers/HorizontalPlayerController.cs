﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlayerController : MonoBehaviour
{
    public float leftExtent = -1.0f;
    public float rightExtent = 1.0f;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 0.1f * MicrogameController.instance.microgameTimescale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-_speed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_speed, 0, 0);
        }

        if(transform.position.x < leftExtent)
        {
            transform.position = new Vector2(leftExtent, transform.position.y);
        }
        if(transform.position.x > rightExtent)
        {
            transform.position = new Vector2(rightExtent, transform.position.y);
        }
    }
}
