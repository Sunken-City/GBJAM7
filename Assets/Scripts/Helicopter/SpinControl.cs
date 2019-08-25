using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinControl : MonoBehaviour
{
    public float startingRotVelocity;
    public bool freezeOnWin = true;

    private float _rotVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _rotVelocity = startingRotVelocity;  
    }

    // Update is called once per frame
    void Update()
    {
        if(freezeOnWin && MicrogameController.instance.HasFinished())
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rotVelocity += 0.5f * MicrogameController.instance.microgameTimescale;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rotVelocity -= 0.5f * MicrogameController.instance.microgameTimescale;
        }

        transform.Rotate(Vector3.forward * _rotVelocity);
    }
}
