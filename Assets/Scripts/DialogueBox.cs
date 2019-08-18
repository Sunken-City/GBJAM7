using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    private Text _dialogueText = null;
    private Text _nameText = null;

    // Start is called before the first frame update
    void Awake()
    {
        _nameText = transform.Find("NameBox").Find("NameText").GetComponent<Text>();
        _dialogueText = transform.Find("TextBox").Find("DialogueText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetDialogue(string text)
    {
        _dialogueText.text = text;
    }
}
