using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    public int maxLife = 1;
    public GameObject player;
    public GameObject[] heartObjects;
    public Material deathTransitionMaterial;
    private int _curLife = 1;
    private bool _lifeLost = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_lifeLost && OverworldController.instance.lastMicrogameState == MicrogameController.State.LOST)
        {
            LoseLife();
        }
        else if(_lifeLost && OverworldController.instance.lastMicrogameState == MicrogameController.State.PLAYING)
        {
            _lifeLost = !_lifeLost;
        }
    }

    public void LoseLife()
    {
        heartObjects[_curLife - 1].GetComponent<Animator>().SetBool("isFull", false);
        --_curLife;
        _lifeLost = true;
        if(_curLife == 0)
        {
            GameOver();
        }
    }

    public void GetLife()
    {
        if(_curLife < maxLife)
        {
            ++_curLife;
        }
    }

    public void GameOver()
    {
        _curLife = maxLife;
        SimpleBlit blit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SimpleBlit>();
        blit.TransitionMaterial = deathTransitionMaterial;
        blit.transitionValue = 1;
        player.GetComponent<OverworldPlayerController>().Respawn();
    }
}
