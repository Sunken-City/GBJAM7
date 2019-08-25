using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightWin : MonoBehaviour
{

    public GameObject target;

    private SpriteRenderer _targetSprite;
    private SpriteMask _spriteMask;
    // Start is called before the first frame update
    void Start()
    {
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
