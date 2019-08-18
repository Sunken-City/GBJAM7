using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour
{
    public Sprite alternateState;
    public GameObject background;

    public string specificTag = string.Empty;

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
        if(!string.IsNullOrEmpty(specificTag) && col.tag != specificTag)
        {
            return;
        }

        if(MicrogameController.instance.HasNotYetWon())
        {
            MicrogameController.instance.WinMicrogame();

            //switch specific stuff lel what a meme what a hack.
            if(alternateState)
            {
                GetComponent<SpriteRenderer>().sprite = alternateState;
            }
            if(background)
            {
                background.GetComponent<SpriteRenderer>().color = Color.white;
            }                
        }
    }
}
