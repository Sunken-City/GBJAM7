﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MicrogameController : MonoBehaviour
{
    public enum State
    {
        NOT_STARTED = 0,
        PLAYING,
        WON,
        LOST,
        NUM_STATES
    }
    public static MicrogameController instance = null;
    public GameObject microgameSubScene = null;
    public AudioClip backgroundMusic = null;
    public bool winOnTimeOut = false;
    private State _microgameState = State.NOT_STARTED;
    public float timeLimitSeconds = 5.0f;
    public float microgameTimescale = 1.0f;
    private float _currentTimerSeconds = 0.0f;
    public GameObject timer;

    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }

        microgameTimescale = OverworldController.instance ? OverworldController.instance.microgameTimescale : microgameTimescale;
        Time.timeScale = microgameTimescale;
        if(backgroundMusic)
        {
            GetComponent<AudioSource>().PlayOneShot(backgroundMusic);
            GetComponent<AudioSource>().pitch = microgameTimescale;
        }

        //Set the speed of the timer to match limit; use 0.29 to scale default animation speed
        timer.GetComponent<Animator>().speed = 1 / (timeLimitSeconds * 0.29f);
    }

    void OnDestroy()
    {
        Debug.Assert(instance == this, "We somehow made a second instance of the microgame controller? :T");
        instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimerSeconds += Time.deltaTime;
        //This is a hack to prevent debug spew. If you're debugging an individual scene, you won't have an Overworld Controller.
        if(OverworldController.instance && _currentTimerSeconds > timeLimitSeconds)
        {
            ReturnToOverworld();
        }
    }

    public void ReturnToOverworld()
    {
        if((HasNotYetWon() && !winOnTimeOut) || HasLost())
        {
            OverworldController.instance.lastMicrogameState = State.LOST;
        }
        else
        {
            OverworldController.instance.lastMicrogameState = State.WON;
        }

        Time.timeScale = 1.0f;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(OverworldController.instance.currentSceneName));
        OverworldController.instance.EndMicrogame();
        Destroy(microgameSubScene);
    }

    public void WinMicrogame()
    {
        if(_microgameState == State.LOST)
        {
            Debug.Log("We've already lost, so we can't win.");
            return;
        }
        _microgameState = State.WON;
        Debug.Log("Large winner!!!");
    }
    public void LoseMicrogame()
    {
        if(_microgameState == State.WON)
        {
            Debug.Log("We've already won, so we can't lose."); //Or can we? To be revisited in case a microgame needs it.
            return;
        }
        _microgameState = State.LOST;
        Debug.Log("Big loser!!!");
    }

    public bool HasWon()
    {
        return _microgameState == State.WON;
    }
    public bool HasLost()
    {
        return _microgameState == State.LOST;
    }

    public bool HasFinished()
    {
        return _microgameState == State.LOST || _microgameState == State.WON;
    }

    public bool HasNotYetWon()
    {
        return (_microgameState == State.PLAYING || _microgameState == State.NOT_STARTED);
    }
}
