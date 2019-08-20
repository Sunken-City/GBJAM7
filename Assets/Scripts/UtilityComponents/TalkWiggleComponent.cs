using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWiggleComponent : MonoBehaviour
{
    public int frameDelay = 20;
    private Vector2 _voiceDisplacementVector;
    private Vector2 _initialPosition;
    private int _frameCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        _voiceDisplacementVector = new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(0.2f, 0.4f));
        _initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(++_frameCounter % frameDelay == 0)
        {
            _voiceDisplacementVector += new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(0.2f, 0.4f));
        }

        _voiceDisplacementVector *= 0.9f;
        transform.localPosition = _initialPosition + _voiceDisplacementVector;
    }
}
