using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolentShakingComponent : MonoBehaviour
{
    public float shakeMagnitude;
    public float magnitudeDelta = 0.0f;
    private Vector2 _homePosition;
    // Start is called before the first frame update
    void Start()
    {
        _homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        shakeMagnitude += magnitudeDelta;
        float displacementX = Random.Range(-1.0f, 1.0f) * shakeMagnitude;
        float displacementY = Random.Range(-1.0f, 1.0f) * shakeMagnitude;
        transform.position = _homePosition + new Vector2(displacementX, displacementY);
    }
}
