using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public float landHeight = -0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MicrogameController.instance.HasFinished())
        {
            transform.position += new Vector3(0.0016f, -.005f, 0f);
        }

        if(transform.position.y <= landHeight && !MicrogameController.instance.HasFinished())
        {
            float angle;
            Vector3 axis;
            transform.rotation.ToAngleAxis(out angle, out axis);

            if (angle < 45)
            {
                MicrogameController.instance.WinMicrogame();
            }
            else
            {
                MicrogameController.instance.LoseMicrogame();
            }

        }
        
    }
}
