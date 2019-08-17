using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolentShakingComponent : MonoBehaviour
{
    public float shakeMagnitude;
    private Vector2 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float displacementX = Random.Range(-1.0f, 1.0f) * shakeMagnitude;
        float displacementY = Random.Range(-1.0f, 1.0f) * shakeMagnitude;
        transform.position = homePosition + new Vector2(displacementX, displacementY);
    }
}
