using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnRotation : MonoBehaviour
{
    
    public float angleOffsetMin = 0.0f;
    public float angleOffsetMax = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 1), Random.Range(angleOffsetMin, angleOffsetMax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
