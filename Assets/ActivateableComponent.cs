using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateableComponent : MonoBehaviour
{
    [HideInInspector]
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }
}
