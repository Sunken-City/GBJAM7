using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnInputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("W") || Input.GetKey("A") || Input.GetKey("S") || Input.GetKey("D") || Input.GetKey("J") || Input.GetKey("K"))
        {
            MicrogameController.instance.LoseMicrogame();
        }
    }
}
