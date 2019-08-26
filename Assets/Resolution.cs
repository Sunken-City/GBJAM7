using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(160, 144, false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
