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
    private int _badAnswerIndex = 3;
    private int _curAnswerIndex;

    // Start is called before the first frame update
    void Start()
    {
        Text[] components = GetComponentsInChildren<Text>();
        _questionComponent = components[0];
        _answerComponent = components[1];
        string[] lines = adviceFile.text.Split('\n');
        string line = lines[Random.Range(0, lines.Length)];
        string[] splitString = line.Split('|');
        Shuffle(ref splitString);
        _questionComponent.text = splitString[0];
        _answerComponent.text = splitString[1] + '\n' + splitString[2] + '\n' + splitString[3];

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
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

    void Shuffle(ref string[] array)
    {
        //Start at 1 so we don't shuffle the question 
        for(int i = 1; i < array.Length; ++i)
        {
            int randIndex = Random.Range(1, array.Length);
            string temp = array[randIndex];
            array[randIndex] = array[i];
            array[i] = temp;
            if (randIndex == _badAnswerIndex)
            {
                _badAnswerIndex = i;
            }
        }
    }
}
