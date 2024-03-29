﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    //public AudioClip
    private Text _dialogueText = null;
    private Text _nameText = null;
    private string _dialogueString;
    private int _frameCounter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _nameText = transform.Find("NameBox").Find("NameText").GetComponent<Text>();
        _dialogueText = transform.Find("TextBox").Find("DialogueText").GetComponent<Text>();
        GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.width != 160.0f)
        {
            float width = Screen.width;
            float height = Screen.height;
            if(height < width)
            {
                GetComponent<CanvasScaler>().scaleFactor = (height / 144.0f);
            }
            else
            {
                GetComponent<CanvasScaler>().scaleFactor = (width / 160.0f);
            }
        }

        if(_frameCounter < _dialogueString.Length)
        {
            _dialogueText.text += _dialogueString.Substring(_frameCounter++, 1);

            AudioSource audio = GetComponent<AudioSource>();
            if(audio.clip)
            {
                audio.PlayOneShot(audio.clip);
            }
        }
    }

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetCurrentDialogue(string text)
    {
        _frameCounter = 0;
        _dialogueString = text;
        _dialogueText.text = "";
    }

    public void SetSample(AudioClip sample)
    {
        GetComponent<AudioSource>().clip = sample;
    }
}
