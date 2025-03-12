using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("# Bullet Type")]
    public BulletType BulletType = BulletType.MainBullet;

    [Header ("# Movement")]
    public float Speed;
    protected Vector3 _direction = new Vector3();

    [Header ("# Snake Movement")]
    protected float _lerpTime = 0f;
    public float Frequency = 10f;
    public bool IsLeftBullet = false;

    [Header("# Stats")]
    public float Damage = 100;

    private void Update()
    {
        //Movement();
        StraightMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(Damage);

            Destroy(gameObject);
        }
    }

    private void StraightMovement()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }

    public virtual void Movement()
    {
        _lerpTime += Time.deltaTime;
        if(_lerpTime > 2 * Mathf.PI)
        {
            _lerpTime = 0f;
        }

        //float h = IsLeftBullet ? Mathf.Cos(Frequency * _lerpTime) : -Mathf.Cos(Frequency * _lerpTime);
        float h = Mathf.Cos(Frequency * _lerpTime);
        _direction = new Vector3(h, 1, 0).normalized;
        transform.Translate(_direction * Speed * Time.deltaTime);
    }
}