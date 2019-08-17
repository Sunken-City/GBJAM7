using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string microgameSceneName;
    public float playerDetectionRadius = 0.5f;
    private bool _hasBeenTriggered = false;
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
        if((!OverworldController.instance.freezeInput &&
        Vector2.Distance(_playerReference.transform.position, transform.position) < playerDetectionRadius) &&
        (Input.GetKey(KeyCode.W) ||
        Input.GetKey(KeyCode.A) ||
        Input.GetKey(KeyCode.S) ||
        Input.GetKey(KeyCode.D)))
        {
            //(playerReference.transform.position - transform.position);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(_hasBeenTriggered)
        {
            return;
        }

        _hasBeenTriggered = !_hasBeenTriggered;
        OverworldController.instance.BeginMicrogame(microgameSceneName, this.gameObject);
    }
}
