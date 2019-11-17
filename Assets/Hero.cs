using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public int castType = 0;

    public int castForm = 0;

    public int castModificator = 0;

    public float castForce = 20f;

    public float castDistance = 2f;

    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Fire();
        }

        if (Input.GetButtonDown("Cast Type 1"))
        {
            this.castType = 0;
        }

        if (Input.GetButtonDown("Cast Type 2"))
        {
            this.castType = 1;
        }

        if (Input.GetButtonDown("Cast Form 1"))
        {
            this.castForm = 0;
        }

        if (Input.GetButtonDown("Cast Form 2"))
        {
            this.castForm = 1;
        }

        if (Input.GetButtonDown("Cast Form 3"))
        {
            this.castForm = 2;
        }

        if (Input.GetButtonDown("Cast Mod 1"))
        {
            this.castModificator = 0;
        }

        if (Input.GetButtonDown("Cast Mod 2"))
        {
            this.castModificator = 1;
        }

        if (Input.GetButtonDown("Cast Mod 3"))
        {
            this.castModificator = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var monster = collision.gameObject.GetComponent<Monster>();
        if (monster is null)
        {
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Fire()
    {
        var castPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var castDirection = (castPosition - (Vector2)transform.position);
        castDirection.Normalize();

        switch (this.castForm)
        {
            case 0:
                CastOne(castDirection);
                break;
            case 1:
                CastMulti(castDirection);
                break;
            case 2:
                CastCircle(castDirection);
                break;
        }
    }

    private void CastOne(Vector2 castDirection)
    {
        var bulletPosition = Vector2.zero + (this.castDistance * castDirection);
        var bulletRotation = Quaternion.identity;
        var bulletObject = Instantiate(this.bulletPrefab, bulletPosition, bulletRotation);
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.type = this.castType;
        bullet.modificator = this.castModificator;
        bullet.Launch(castDirection, this.castForce);
    }

    private void CastMulti(Vector2 direction)
    {
        CastOne(direction);
        CastOne(Quaternion.Euler(0, 0, +30f) * direction);
        CastOne(Quaternion.Euler(0, 0, -30f) * direction);
    }

    private void CastCircle(Vector2 direction)
    {
        float angle = 0f;
        for (int i = 0; i < 36; i++)
        {
            CastOne(Quaternion.Euler(0, 0, angle) * direction);
            angle += 10f;
        }
    }
}
