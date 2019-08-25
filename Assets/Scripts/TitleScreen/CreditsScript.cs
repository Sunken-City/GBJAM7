using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public TextAsset creditsFile;
    public Camera camera;
    private Text _textComponent = null;
    private Vector2 _relativePosition;
    //private string _credits;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent = gameObject.GetComponent<Text>();
        _textComponent.text = creditsFile.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            transform.position += new Vector3(0, 0.02f, 0);
        }
        else
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
        _relativePosition = camera.transform.InverseTransformDirection(transform.position - camera.transform.position);
        if(_relativePosition.y > (_textComponent.preferredHeight / 100))
        {
            SceneManager.LoadScene("TitleScreen");
            //Destroy(gameObject);
        }
    }
}
