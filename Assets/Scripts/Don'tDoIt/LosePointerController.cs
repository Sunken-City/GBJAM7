using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePointerController : MonoBehaviour
{
    private bool _hasMoved = false;
    public GameObject loseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_hasMoved)
        {
            if (MicrogameController.instance.HasLost())
            {
                GetComponent<ViolentShakingComponent>().enabled = false;
                transform.position += new Vector3(0, -0.4f, 0);
                loseText.SetActive(true);
                _hasMoved = true;
            }
        }
    }
}
