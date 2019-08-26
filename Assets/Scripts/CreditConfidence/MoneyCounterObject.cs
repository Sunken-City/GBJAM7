using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounterObject : MonoBehaviour
{
    private int numCharges = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(numCharges > 5 && MicrogameController.instance.HasNotYetWon())
        {
            MicrogameController.instance.WinMicrogame();
        }
    }

    public void ChargeCreditCard()
    {
        ++numCharges;
        GetComponent<Text>().text += "$";
        GetComponent<ViolentShakingComponent>().shakeMagnitude += 0.05f;
    }
}
