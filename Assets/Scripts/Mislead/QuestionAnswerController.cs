﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswerController : MonoBehaviour
{
    public TextAsset adviceFile;
    public GameObject selector;
    public GameObject victory;
    public GameObject loss;
    public GameObject concernedDude;
    private ScrollTextController _questionComponent;
    private Text _answerComponent;
    private string[] _advice;
    private int _badAnswerIndex = 3;
    private int _curAnswerIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        Text[] components = GetComponentsInChildren<Text>();
        _questionComponent = GetComponentInChildren<ScrollTextController>();
        _answerComponent = components[1];
        string[] lines = adviceFile.text.Split('\n');
        string line = lines[Random.Range(0, lines.Length - 1)];
        _advice = line.Split('|');
        Shuffle();
        _questionComponent.text = _advice[0];
        _answerComponent.text = _advice[1] + '\n' + _advice[2] + '\n' + _advice[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (_questionComponent.IsDone())
        {
            concernedDude.GetComponent<TalkWiggleComponent>().enabled = false;
        }
        if (MicrogameController.instance.HasLost() || MicrogameController.instance.HasWon())
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (_curAnswerIndex < _advice.Length - 1)
            {
                selector.transform.position += new Vector3(0, -0.09f, 0);
                _curAnswerIndex++;
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            if (_curAnswerIndex > 1)
            {
                selector.transform.position += new Vector3(0, 0.09f, 0);
                _curAnswerIndex--;
            }
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            selector.SetActive(false);
            concernedDude.GetComponent<TalkWiggleComponent>().enabled = true;
            _questionComponent.text = "That's a great idea!";
            _questionComponent.Reset();
            _answerComponent.text = _advice[_curAnswerIndex];
            if (_curAnswerIndex == _badAnswerIndex)
            {
                MicrogameController.instance.WinMicrogame();
                victory.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                MicrogameController.instance.LoseMicrogame();
                loss.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void Shuffle()
    {
        //Start at 1 so we don't shuffle the question 
        for(int i = 1; i < _advice.Length; ++i)
        {
            int randIndex = Random.Range(1, _advice.Length - 1);
            string temp = _advice[randIndex];
            _advice[randIndex] = _advice[i];
            _advice[i] = temp;
            if(randIndex == _badAnswerIndex)
            {
                _badAnswerIndex = i;
            }
            else if(i == _badAnswerIndex)
            {
                _badAnswerIndex = randIndex;
            }
        }
    }
}
