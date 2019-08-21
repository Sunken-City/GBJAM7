using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoochHandler : MonoBehaviour
{

    public GameObject lips;
    public GameObject heart;

    private InflateController _inflateController;
    // Start is called before the first frame update
    void Start()
    {
        lips.SetActive(false);
        heart.SetActive(false);
        _inflateController = GetComponent<InflateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MicrogameController.instance.HasWon())
        {
            heart.SetActive(true);
            lips.SetActive(true);
            
        }
    }
}
