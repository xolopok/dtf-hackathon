using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type = 0;

    public int modificator = 0;

    public GameObject shardPrefab;

    public float explosionForce = 50f;

    private void Update()
    {
        if (transform.position.magnitude > 50.0f)
        {
            Debug.Log("Projectile travel too long.");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile collided with " + other.gameObject);

        var monster = other.gameObject.GetComponent<Monster>();
        if (monster is null)
        {
            return;
        }
        else
        {
            DamageMonster(monster);
        }

        switch (this.modificator)
        {
            case 0:
                Destroy(gameObject);
                break;
            case 1:
                break;
            case 2:
                Destroy(gameObject);
                Explode();
                break;
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(direction * force);
    }

    private void Explode()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        float angle = 0f;
        for (int i = 0; i < 6; i++)
        {
            SpawnShard(rigidbody.position, Quaternion.Euler(0, 0, angle) * Vector2.up);
            angle += 60f;
        }
    }

    private void SpawnShard(Vector2 castOrigin, Vector2 castDirection)
    {
        var bulletObject = Instantiate(this.shardPrefab, castOrigin, Quaternion.identity);
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.type = this.type;
        bullet.modificator = 0;
        bullet.Launch(castDirection, this.explosionForce);
    }

    private void DamageMonster(Monster monster)
    {
        monster.health -= (int)(50 * monster.damageFactor);
        if (monster.health <= 0)
        {
            Destroy(monster.gameObject);
        }
    }
}
