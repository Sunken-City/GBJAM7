using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour
{
    public Text subText;
    private int frameCounter = 0;
    public int finalTextSize = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Scale down from a large size
        int fontSize = 30 - ++frameCounter;
        fontSize = Mathf.Max(fontSize, finalTextSize);
        GetComponent<Text>().fontSize = fontSize;
        if(subText)
        {
            subText.fontSize = fontSize;
        }

        //Text wigglies
        if(frameCounter % 4 != 0)
        {
            return;
        }
        string currentText = GetComponent<Text>().text;
        currentText = randomizeStringCapitalization(currentText);
        GetComponent<Text>().text = currentText;
        if(subText)
        {
            subText.text = currentText;
        }
    }

    string randomizeStringCapitalization(string text)
    {
        //Thanks to the magic of Angry Dad Font, this provides a slight wiggle to the text, since it's all in caps.
        string newText = "";
        for(int i = 0; i < text.Length; ++i)
        {
            newText += Random.Range(0,2) == 0 ? text.Substring(i, 1).ToUpper() : text.Substring(i, 1).ToLower();
        }
        return newText;
    }
}
