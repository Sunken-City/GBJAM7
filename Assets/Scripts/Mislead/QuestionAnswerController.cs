using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswerController : MonoBehaviour
{
    public TextAsset adviceFile;
    public Sprite selector;
    private Text _questionComponent;
    private Text _answerComponent;
    private string[] _advice;
    private int _badAnswerIndex = 3;
    private int _curAnswerIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        Text[] components = GetComponentsInChildren<Text>();
        _questionComponent = components[0];
        _answerComponent = components[1];
        string[] lines = adviceFile.text.Split('\n');
        string line = lines[Random.Range(0, lines.Length)];
        _advice = line.Split('|');
        Shuffle();
        _questionComponent.text = _advice[0];
        _answerComponent.text = _advice[1] + '\n' + _advice[2] + '\n' + _advice[3];

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {

        }

        if(Input.GetKey(KeyCode.J))
        {
            _questionComponent.text = _advice[_curAnswerIndex];
            _answerComponent.text = "That's a great idea!";
            if (_curAnswerIndex == _badAnswerIndex)
            {
                MicrogameController.instance.WinMicrogame();
            }
            else
            {
                MicrogameController.instance.LoseMicrogame();
            }
        }
    }

    void Shuffle()
    {
        //Start at 1 so we don't shuffle the question 
        for(int i = 1; i < _advice.Length; ++i)
        {
            int randIndex = Random.Range(1, _advice.Length);
            string temp = _advice[randIndex];
            _advice[randIndex] = _advice[i];
            _advice[i] = temp;
            if (randIndex == _badAnswerIndex)
            {
                _badAnswerIndex = i;
            }
        }
    }
}
