using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSquishedGameController : MonoBehaviour
{

 
    public static int numOfSquishedSlimes;
    private int numOfSlimes = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (numOfSquishedSlimes == numOfSlimes)
        {
        MicrogameController.instance.WinMicrogame();
         }
    }
}
