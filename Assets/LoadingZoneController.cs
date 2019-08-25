using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZoneController : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject player;
    public AudioClip newBackgroundMusic;
    public float newMicrogameTimescale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(newBackgroundMusic)
        {
            OverworldController.instance.SetBGM(newBackgroundMusic);
        }
        OverworldController.instance.microgameTimescale = newMicrogameTimescale;
        OverworldController.instance.SetBGMPitch(newMicrogameTimescale);
        player.transform.position = new Vector2(x, y);
        OverworldPlayerController.playerRespawnLocation = player.transform.position;
    }
}
