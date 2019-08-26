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
        gameObject.GetComponent<SpriteRenderer>().transform.position = new Vector3(-1.21f, -0.013f, -2.325573f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && _curOption < numOptions - 1)
        {
            ++_curOption;
            gameObject.GetComponent<SpriteRenderer>().transform.position = new Vector3(-0.205f, -0.038f, 0f); 
        }
        if(Input.GetKeyDown(KeyCode.A) && _curOption > 0)
        {
            --_curOption;
            gameObject.GetComponent<SpriteRenderer>().transform.position = new Vector3(-1.21f, -0.013f, 0f); 
        }
        if(Input.GetKeyUp(KeyCode.J))
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
