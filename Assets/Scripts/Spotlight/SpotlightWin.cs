using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightWin : MonoBehaviour
{

    public GameObject target;

    private SpriteRenderer _targetSprite;
    private SpriteMask _spriteMask;
    private Vector3[] targetPositions =
    {
        new Vector3(0.257f, 0.616f, 0),
        new Vector3(0.495f, -0.44f, 0),
        new Vector3(-0.456f, 0.54f, 0),
        new Vector3(0.683f, 0.568f, 0),
        new Vector3(-0.182f, 0.226f, 0)
    };
    // Start is called before the first frame update
    void Start()
    {
        target.transform.position = targetPositions[Random.Range(0, targetPositions.Length - 1)];
        _spriteMask = GetComponent<SpriteMask>();
        _targetSprite = target.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dispVector = transform.position - target.transform.position;
        if (dispVector.magnitude + _targetSprite.bounds.size.x -0.1  < _spriteMask.sprite.bounds.size.x)
        {
            MicrogameController.instance.WinMicrogame();
        }
    }
}
