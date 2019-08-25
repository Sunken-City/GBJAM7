using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSelectorComponent : MonoBehaviour
{
    public int numOptions = 0;
    public int _curOption = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && _curOption < numOptions - 1)
        {
            ++_curOption;
            gameObject.GetComponent<SpriteRenderer>().transform.position += new Vector3(0, -0.2f, 0);
        }
        if(Input.GetKeyDown(KeyCode.W) && _curOption > 0)
        {
            --_curOption;
            gameObject.GetComponent<SpriteRenderer>().transform.position += new Vector3(0, 0.2f, 0);
        }
        if(Input.GetKey(KeyCode.J))
        {
            if(_curOption == 0)
            {
                SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
            }
            else if (_curOption == 1)
            {
                SceneManager.LoadScene("Credits", LoadSceneMode.Single);
            }
        }
    }
}
