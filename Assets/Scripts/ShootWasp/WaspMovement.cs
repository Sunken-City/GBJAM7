using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspMovement : MonoBehaviour
{
    public GameObject crossHair;
    public AudioClip failedShootSound;

    private float _t;
    private SpriteRenderer _waspSprite;
    private float _reloadTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _waspSprite = GetComponent<SpriteRenderer>();
        _t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (MicrogameController.instance.HasWon())
        {
            return;
        }

        if (_reloadTimer > 0)
        {
            _reloadTimer -= Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.J) && _reloadTimer <= 0)
        {
            AudioSource audioSource = MicrogameController.instance.GetComponent<AudioSource>();
            audioSource.clip = failedShootSound;
            audioSource.Play();

            _reloadTimer = 0.2f;

            if (_waspSprite.bounds.Contains(crossHair.transform.position))
            {
                MicrogameController.instance.WinMicrogame();
            }
        }
            
        _t += Time.deltaTime * 3.0f * MicrogameController.instance.microgameTimescale;

        transform.position = new Vector3(Mathf.Cos(_t)/2 - Mathf.Cos(_t/2)/3, Mathf.Sin(_t)/2);
        
    }
}
