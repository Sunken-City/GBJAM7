using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTextController : MonoBehaviour
{
    public string text;
    private int _pos = 0;
    private Text _textComponent;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDone())
        {
            _textComponent.text = text.Substring(0, _pos);
            _pos++;
        }
    }

    public void Reset()
    {
        _pos = 0;
    }

    public bool IsDone()
    {
        return _pos == text.Length + 1;
    }
}
