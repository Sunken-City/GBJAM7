using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlsComponent : MonoBehaviour
{
    public bool freezeOnVictory = false;
    public bool freezeOnLoss = false;
    private float _speed;
    private float _angleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 0.01f * MicrogameController.instance.microgameTimescale;
        _angleSpeed = 1.0f * MicrogameController.instance.microgameTimescale;
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
            transform.Rotate(new Vector3(0, 0, 1), _angleSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, 1), -_angleSpeed);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position -= transform.right * _speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += transform.right * _speed;
        }
    }
}
