using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectInRadius : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float secondsPerSpawn = 1.0f;
    public float radius = 0.3f;
    private float _timeSinceLastSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        while(_timeSinceLastSpawn >= secondsPerSpawn)
        {
            SpawnObject();
            _timeSinceLastSpawn -= secondsPerSpawn;
        }
    }

    private Vector2 GetRandomVectorInCircle()
    {
        float t = Mathf.PI * 2.0f * Random.Range(0.0f, 1.0f);
        float r = Mathf.Sqrt(Random.Range(0.0f, 1.0f)) * radius;
        return new Vector2(r * Mathf.Cos(t), r * Mathf.Sin(t));
    }

    private void SpawnObject()
    {
        Vector2 foundPosition = (Vector2)transform.position + GetRandomVectorInCircle();
        Instantiate(objectToSpawn, foundPosition, transform.rotation);
    }
}
