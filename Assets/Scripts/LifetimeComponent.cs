using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeComponent : MonoBehaviour
{
    public float lifetimeSeconds = 1.5f;
    private float _currentTimerSeconds = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimerSeconds += Time.deltaTime;
        if(_currentTimerSeconds > lifetimeSeconds)
        {
            Destroy(this.gameObject);
        }        
    }
}
