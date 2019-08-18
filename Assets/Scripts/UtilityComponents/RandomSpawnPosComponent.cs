using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnPosComponent : MonoBehaviour
{
    public Bounds spawnRegion;

    // Start is called before the first frame update
    void Start()
    {
        float spawnX = Random.Range(spawnRegion.min.x, spawnRegion.max.x);
        float spawnY = Random.Range(spawnRegion.min.y, spawnRegion.max.y);
        transform.position = new Vector2(spawnX, spawnY);
    }
}
