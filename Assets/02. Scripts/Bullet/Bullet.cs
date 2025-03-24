using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("# Data")]
    public BulletDataSO Data;

    [Header ("# Movement")]
    protected Vector3 _direction = new Vector3();

    [Header ("# Snake Movement")]
    //protected float _lerpTime = 0f;
    //public float Frequency = 10f;

    protected DamageInfo _damage;

    private void Awake()
    {
        _damage.Value = Data.Damage;
        _damage.Type = EDamageType.Bullet;
        _damage.From = gameObject;
    }

    private void Update()
    {
        //Movement();
        StraightMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            // 묻지 말고 시켜라!
            collision.GetComponent<Enemy>().TakeDamage(_damage);

            PoolManager.Instance.ReturnObject(gameObject, Data.ObjectType);
        }
        else if(collision.CompareTag("Boss"))
        {
            collision.GetComponent<Boss>().TakeDamage(_damage);

            PoolManager.Instance.ReturnObject(gameObject, Data.ObjectType);
        }

        if (collision.CompareTag("DestroyZone"))
        {
            PoolManager.Instance.ReturnObject(gameObject, Data.ObjectType);
        }
    }

    private void StraightMovement()
    {
        transform.Translate(Vector3.up * Data.Speed * Time.deltaTime);
    }

    /*public virtual void Movement()
    {
        _lerpTime += Time.deltaTime;
        if(_lerpTime > 2 * Mathf.PI)
        {
            _lerpTime = 0f;
        }

        //float h = IsLeftBullet ? Mathf.Cos(Frequency * _lerpTime) : -Mathf.Cos(Frequency * _lerpTime);
        float h = Mathf.Cos(Frequency * _lerpTime);
        _direction = new Vector3(h, 1, 0).normalized;
        transform.Translate(_direction * Data.Speed * Time.deltaTime);
    }*/
}