using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflate : MonoBehaviour
{

    public GameObject Lips;
    public GameObject Heart;

    private InflateController _inflateController;
    // Start is called before the first frame update
    void Start()
    {
        this.Lips.SetActive(false);
        _inflateController = GetComponent<InflateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MicrogameController.instance.HasWon())
        {
            this.Lips.SetActive(true);
            transform.localScale = new Vector3(3.2f, 3.1f, 6.7f);
            return;
        }
    }
}
