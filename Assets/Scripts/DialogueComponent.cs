using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueComponent : MonoBehaviour
{
    public string characterName;
    public string[] textBlocks;
    public float interactRadius = 0.2f;
    public AudioClip soundEffect = null;
    public GameObject dialogueBoxPrefab;
    public GameObject activateableObject;
    private GameObject _dialogueBoxInstance = null;
    private GameObject _playerReference = null;
    private int _dialogueIndex = 0;

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
                _dialogueIndex = 0;
                _dialogueBoxInstance = Instantiate(dialogueBoxPrefab);
                _dialogueBoxInstance.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                DialogueBox dialogue = _dialogueBoxInstance.GetComponent<DialogueBox>();
                if(soundEffect)
                {
                    dialogue.SetSample(soundEffect);
                }
                dialogue.SetName(characterName);
                dialogue.SetCurrentDialogue(textBlocks[_dialogueIndex]);
                OverworldController.instance.freezeInput = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.K))
        {
            if(++_dialogueIndex < textBlocks.Length)
            {
                _dialogueBoxInstance.GetComponent<DialogueBox>().SetCurrentDialogue(textBlocks[_dialogueIndex]);
            }
            else
            {
                if(activateableObject)
                {
                    activateableObject.SetActive(true);
                }
                Destroy(_dialogueBoxInstance);
                _dialogueBoxInstance = null;
                OverworldController.instance.freezeInput = false;
            }
        }
    }
}
