using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = .7f;

    public float spawnRadius = 20;

    public GameObject monsterPrefab;

    private float nextTimeToSpawn = 0f;

    private void Update()
    {
        if (Time.time >= this.nextTimeToSpawn)
        {
            Spawn();
            this.nextTimeToSpawn = Time.time + (1f / this.spawnRate);
        }
    }

    private void Spawn()
    {
        var spawnPosition = GetSpawnPosition();
        _ = Instantiate(this.monsterPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector2 GetSpawnPosition()
    {
        var angle = Random.value * 360;
        return new Vector2(
            transform.position.x + (this.spawnRadius * Mathf.Sin(angle * Mathf.Deg2Rad)),
            transform.position.y + (this.spawnRadius * Mathf.Cos(angle * Mathf.Deg2Rad)));
    }
}
