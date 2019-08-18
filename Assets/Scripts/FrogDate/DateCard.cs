using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateCard : MonoBehaviour
{
    public Sprite ourBoyImage;
    public Sprite[] babeImages;
    public TextAsset babeNames;
    public bool isOurBoy = false;
    private Vector2 _directionOfMotion = Vector2.zero;

    void Awake()
    {
        string[] babeNamesRaw = babeNames.text.Split('\n');
        string babeName = babeNamesRaw[Random.Range(0, babeNamesRaw.Length)];
        transform.Find("Text").GetComponent<Text>().text = babeName + "," + Random.Range(18, 32);

        transform.Find("Photo").GetComponent<Image>().sprite = babeImages[Random.Range(0, babeImages.Length)];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = (Vector2)transform.position + _directionOfMotion;
    }

    public void MakeOurBoy()
    {
        transform.Find("Photo").GetComponent<Image>().sprite = ourBoyImage;
        isOurBoy = true;
    }

    public void SwipeRight()
    {
        _directionOfMotion = new Vector2(0.1f, 0.0f);
        if(isOurBoy)
        {
            MicrogameController.instance.WinMicrogame();
        }
        else
        {
            MicrogameController.instance.LoseMicrogame();
        }
    }

    public void SwipeLeft()
    {
        _directionOfMotion = new Vector2(-0.1f, 0.0f);    
        if(isOurBoy)
        {
            MicrogameController.instance.LoseMicrogame();
        }    
    }
}
