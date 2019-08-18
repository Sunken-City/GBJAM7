using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    {
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

    public void SetDialogue(string text)
    {
        _dialogueString = text;
        _dialogueText.text = "";
    }

    public void SetSample(AudioClip sample)
    {
        GetComponent<AudioSource>().clip = sample;
    }
}
