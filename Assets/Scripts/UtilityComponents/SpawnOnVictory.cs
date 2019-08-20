using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnVictory : MonoBehaviour
{
    public GameObject[] objectsToSpawn = null;
    private bool _hasTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objectsToSpawn.Length > 0 && !_hasTriggered && MicrogameController.instance.HasWon())
        {
            _hasTriggered = true;
            foreach (GameObject objectToSpawn in objectsToSpawn)
            {
                Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            }
        }
    }
}
