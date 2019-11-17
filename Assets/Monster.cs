using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public int health = 100;

    public float damageFactor = 0.95f;

    public float speed = 40f;

    private void Start()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        var direction = Vector2.zero - rigidbody.position;
        direction.Normalize();
        rigidbody.AddForce(direction * this.speed);
    }

    private void Update()
    {
        
    }
}
