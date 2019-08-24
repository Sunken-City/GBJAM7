using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string microgameSceneName;
    public float playerDetectionRadius = 0.6f;
    public float movementSpeed = 0.005f;
    private bool _hasBeenTriggered = false;
    private bool _isInvulnerable = false;
    private int _frameCounter = 0;
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
        ++_frameCounter;
        if(_isInvulnerable)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            bool isVisible = sprite.enabled;
            sprite.enabled = (_frameCounter % 4) == 0 ? !sprite.enabled : sprite.enabled;
            return;
        }

        if ((!_hasBeenTriggered &&
        Vector2.Distance(_playerReference.transform.position, transform.position) < playerDetectionRadius) &&
        ((Input.GetKey(KeyCode.W) ||
        Input.GetKey(KeyCode.A) ||
        Input.GetKey(KeyCode.S) ||
        Input.GetKey(KeyCode.D)) || OverworldController.instance.allowGangUp))
        {
            Vector2 displacement = (_playerReference.transform.position - transform.position);
            displacement.Normalize();
            transform.position += (Vector3)(displacement * movementSpeed);
        }
    }

    public void Reset()
    {
        StartCoroutine("TemporaryInvulnerability");
    }
    
    IEnumerator TemporaryInvulnerability()
    {
        _isInvulnerable = true;
        yield return new WaitForSeconds(3.0f);

        _hasBeenTriggered = false;
        _isInvulnerable = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(_hasBeenTriggered || col.gameObject.tag != "Player")
        {
            return;
        }

        _hasBeenTriggered = !_hasBeenTriggered;
        OverworldController.instance.BeginMicrogame(microgameSceneName, this.gameObject);
    }
}
