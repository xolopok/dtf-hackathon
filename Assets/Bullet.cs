using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        Debug.Log("Projectile created at " + this._rigidbody.position);
    }

    void Update()
    {
        if (transform.position.magnitude > 10.0f)
        {
            Debug.Log("Projectile travel too long.");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile collided with " + other.gameObject);
        Destroy(gameObject);
    }

    public void Launch(Vector2 direction, float force)
    {
        this._rigidbody.AddForce(direction * force);
    }
}
