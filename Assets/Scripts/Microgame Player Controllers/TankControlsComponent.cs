﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlsComponent : MonoBehaviour
{
    public bool freezeOnVictory = false;
    public bool freezeOnLoss = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((freezeOnVictory && MicrogameController.instance.HasWon()) || (freezeOnLoss && MicrogameController.instance.HasLost()))
        {
            return;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 1), 1.0f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 1), -1.0f);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position -= transform.right * 0.01f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += transform.right * 0.01f;
        }
    }
}
