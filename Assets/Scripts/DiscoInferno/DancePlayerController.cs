using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancePlayerController : MonoBehaviour
{
    public bool freezeOnVictory = false;
    public bool freezeOnLoss = false;
    public Sprite[] danceSprites;
    public AudioClip[] danceSounds;

    private int _numDanceMoves = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((freezeOnVictory && MicrogameController.instance.HasWon()) || (freezeOnLoss && MicrogameController.instance.HasLost()))
        {
            return;
        }
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        DirectionBounce bounce = GetComponent<DirectionBounce>();
        AudioSource audio = GetComponent<AudioSource>();
        if(Input.GetKeyDown(KeyCode.A))
        {
            renderer.sprite = danceSprites[1];
            bounce.bounceDirection = new Vector2(-0.1f, 0.0f);
            audio.PlayOneShot(danceSounds[0]);
            ++_numDanceMoves;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            renderer.sprite = danceSprites[2];  
            bounce.bounceDirection = new Vector2(0.1f, 0.0f);     
            audio.PlayOneShot(danceSounds[1]); 
            ++_numDanceMoves;    
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            renderer.sprite = danceSprites[3];   
            bounce.bounceDirection = new Vector2(0.0f, 0.1f);      
            audio.PlayOneShot(danceSounds[2]);   
            ++_numDanceMoves;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            renderer.sprite = danceSprites[4];           
            bounce.bounceDirection = new Vector2(0.0f, -0.1f);   
            audio.PlayOneShot(danceSounds[3]);  
            ++_numDanceMoves;
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            renderer.sprite = danceSprites[5];  
            bounce.bounceDirection = new Vector2(0.0f, 0.0f);     
            audio.PlayOneShot(danceSounds[4]);    
            ++_numDanceMoves;     
        }

        if(_numDanceMoves > 15 && MicrogameController.instance.HasNotYetWon())
        {
            MicrogameController.instance.WinMicrogame();
        }
    }
}
