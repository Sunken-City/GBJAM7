using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueComponent : MonoBehaviour
{
    public string characterName;
    public string text;
    public float interactRadius = 0.2f;
    public GameObject dialogueBoxPrefab;
    private GameObject _dialogueBoxInstance = null;
    private GameObject _playerReference = null;

    // Start is called before the first frame update
    void Start()
    {
        _playerReference = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(_playerReference, "Enemies in the scene need to have the player tagged as 'Player'");
    }

    // Update is called once per frame
    void Update()
    {
        if(!_dialogueBoxInstance)
        {
            if(Vector2.Distance(_playerReference.transform.position, transform.position) < interactRadius && Input.GetKeyUp(KeyCode.J))
            {
                _dialogueBoxInstance = Instantiate(dialogueBoxPrefab);
                _dialogueBoxInstance.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                DialogueBox dialogue = _dialogueBoxInstance.GetComponent<DialogueBox>();
                dialogue.SetName(characterName);
                dialogue.SetDialogue(text);
                OverworldController.instance.freezeInput = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.K))
        {
            Destroy(_dialogueBoxInstance);
            _dialogueBoxInstance = null;
            OverworldController.instance.freezeInput = false;
        }
    }
}
