using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingZoneController : MonoBehaviour
{
    public int x;
    public int y;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(x, y);
    }
}
