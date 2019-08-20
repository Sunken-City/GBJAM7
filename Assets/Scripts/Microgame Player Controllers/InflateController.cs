using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflateController : MonoBehaviour
{
    public float growMultiplier = 1.1f;
    public float winMagnitude = 10.0f;

    public bool pressOnlyOnce = false;

    public float Scale
    {
        get { return _currentScale; }
    }
    public bool CanContinueToInflate
    {
        get { return _canContinueToInflate; }
    }

    public float _currentScale = 1.0f;
    private Vector3 _startingScale;
    private bool _canContinueToInflate = true;

    // Start is called before the first frame update
    void Start()
    {
        _startingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && (pressOnlyOnce ? _canContinueToInflate : true))
        {
            _currentScale *= growMultiplier;
        }

        if (pressOnlyOnce && Input.GetKeyUp(KeyCode.J))
        {
            _canContinueToInflate = false;
        }

        transform.localScale = _startingScale * _currentScale;

        if (_currentScale >= winMagnitude && (pressOnlyOnce ? !_canContinueToInflate : true))
        {
            MicrogameController.instance.WinMicrogame();
        }
        else if (pressOnlyOnce && !_canContinueToInflate)
        {
            MicrogameController.instance.LoseMicrogame();
        }
    }
}
