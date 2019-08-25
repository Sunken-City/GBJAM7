using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    public TextAsset creditsFile;
    //private string _credits;

    // Start is called before the first frame update
    void Start()
    {
        //_credits = creditsFile.text;
        gameObject.GetComponent<Text>().text = creditsFile.text;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.005f, 0);
    }
}
