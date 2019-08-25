using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SlimeSquishedGameController;

public class Squished : MonoBehaviour
{
    private bool _hasBeenSquished = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_hasBeenSquished)
        {
            return;
        }
        
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, 0.3f, transform.localScale.z), 0.1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!_hasBeenSquished) 
        {
            ++numOfSquishedSlimes;
            _hasBeenSquished = true;
        }
    }
}
