using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = .7f;

    public GameObject linePrefab;

    private float nextTimeToSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= this.nextTimeToSpawn)
        {
            _ = Instantiate(this.linePrefab, Vector3.zero, Quaternion.identity);
            this.nextTimeToSpawn = Time.time + (1f / this.spawnRate);
        }
    }
}
