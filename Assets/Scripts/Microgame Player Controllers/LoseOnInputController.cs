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
        bool pressedW = Input.GetKey(KeyCode.W);
        bool pressedA = Input.GetKey(KeyCode.A);
        bool pressedS = Input.GetKey(KeyCode.S);
        bool pressedD = Input.GetKey(KeyCode.D);
        bool pressedJ = Input.GetKey(KeyCode.J);
        bool pressedK = Input.GetKey(KeyCode.K);
        if(pressedW || pressedA || pressedS || pressedD || pressedJ || pressedK)
        {
            MicrogameController.instance.LoseMicrogame();
        }
    }
}
