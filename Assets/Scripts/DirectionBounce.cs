using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBounce : MonoBehaviour
{
    public Vector2 bounceDirection;
    public float deformationDelta = 0.1f;

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
        transform.position =  Vector2.Lerp(_homePosition + bounceDirection, _homePosition - bounceDirection, Mathf.PingPong(Time.time, 1.0f));
        transform.localScale =  Vector2.Lerp(_homeScale + (bounceDirection * deformationDelta), _homeScale - (bounceDirection * deformationDelta), Mathf.PingPong(Time.time, 1.0f));
    }
}
