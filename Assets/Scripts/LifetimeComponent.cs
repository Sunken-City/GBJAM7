using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeComponent : MonoBehaviour
{
    public float lifetimeSeconds = 1.5f;
    private float currentTimerSeconds = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimerSeconds += Time.deltaTime;
        if(currentTimerSeconds > lifetimeSeconds)
        {
            Destroy(this.gameObject);
        }        
    }
}
