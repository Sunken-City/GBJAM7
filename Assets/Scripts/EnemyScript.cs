using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string microgameSceneName;
    public float playerDetectionRadius = 0.5f;
    private bool hasBeenTriggered = false;
    private GameObject playerReference = null;


    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(playerReference, "Enemies in the scene need to have the player tagged as 'Player'");
    }

    // Update is called once per frame
    void Update()
    {
        if((!OverworldController.instance.freezeInput &&
        Vector2.Distance(playerReference.transform.position, transform.position) < playerDetectionRadius) &&
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
        if(hasBeenTriggered)
        {
            return;
        }

        hasBeenTriggered = !hasBeenTriggered;
        OverworldController.instance.BeginMicrogame(microgameSceneName, this.gameObject);
    }
}
