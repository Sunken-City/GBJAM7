using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIRescale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
 
    }
}
