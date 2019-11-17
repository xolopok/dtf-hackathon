using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hero : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Vector2 _castPosition;

    public int castType = 0;

    public int castForm = 0;

    public float castForce = 20f;

    public float castDistance = 2f;

    public GameObject bulletPrefab;

    void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this._castPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    public void OnFire()
    {
        var direction = (this._castPosition - this._rigidbody.position);
        direction.Normalize();

        switch (this.castForm)
        {
            case 0:
                CastOne(direction);
                break;
            case 1:
                CastMulti(direction);
                break;
            case 2:
                CastCircle(direction);
                break;
        }
    }

    public void OnSetFire()
    {
        this.castType = 0;
    }

    public void OnSetCold()
    {
        this.castType = 1;
    }

    public void OnSetOne()
    {
        this.castForm = 0;
    }

    public void OnSetMulti()
    {
        this.castForm = 1;
    }

    public void OnSetCircle()
    {
        this.castForm = 2;
    }

    private void CastOne(Vector2 castDirection)
    {
        var angle = (Mathf.Atan2(this._rigidbody.position.y, this._rigidbody.position.x) * Mathf.Rad2Deg) + 90f;
        var bulletPosition = this._rigidbody.position + (this.castDistance * castDirection);
        var bulletRotation = Quaternion.Euler(0, 0, angle);
        var bulletObject = Instantiate(this.bulletPrefab, bulletPosition, bulletRotation);
        var bullet = bulletObject.GetComponent<Bullet>();
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
