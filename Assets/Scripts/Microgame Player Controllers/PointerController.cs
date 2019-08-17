using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
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
        UpdateInput();
    }

    void UpdateInput() 
    {
        if((freezeOnVictory && MicrogameController.instance.HasWon()) || (freezeOnLoss && MicrogameController.instance.HasLost()))
        {
            return;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.01f, 0);
        }
    }
}
