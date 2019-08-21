using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBounce : MonoBehaviour
{
    public Vector2 bounceDirection;
    public Vector2 scaleDelta;
    public float frequencySeconds = 1.0f;

    private Vector2 _homePosition;
    private Vector2 _homeScale;

    // Start is called before the first frame update
    void Start()
    {
        _homePosition = transform.position;
        _homeScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  Vector2.Lerp(_homePosition + bounceDirection, _homePosition - bounceDirection, Mathf.PingPong(Time.time, frequencySeconds));
        transform.localScale =  Vector2.Lerp(_homeScale + scaleDelta, _homeScale - scaleDelta, Mathf.PingPong(Time.time, frequencySeconds));
    }
}
