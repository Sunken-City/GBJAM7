using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public Sprite alternateState;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(MicrogameController.instance.HasNotYetWon())
        {
            MicrogameController.instance.WinMicrogame();
            GetComponent<SpriteRenderer>().sprite = alternateState;
            background.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
