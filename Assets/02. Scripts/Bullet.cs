using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    protected Vector3 _direction = new Vector3();

    [Header ("# Snake Movement")]
    protected float _lerpTime = 0f;
    public float Frequency = 10f;
    public bool IsLeftBullet = false;

    private void Update()
    {
        SnakeMovement();
        //MoveUpper();
    }

    private void MoveUpper()
    {
        _direction = Vector3.up;
        transform.Translate(_direction * Speed * Time.deltaTime);
    }

    protected virtual void SnakeMovement()
    {
        _lerpTime += Time.deltaTime;
        if(_lerpTime > 2 * Mathf.PI)
        {
            _lerpTime = 0f;
        }

        float h = IsLeftBullet ? Mathf.Cos(Frequency * _lerpTime) : -Mathf.Cos(Frequency * _lerpTime);
        _direction = new Vector3(h, 1, 0).normalized;
        transform.Translate(_direction * Speed * Time.deltaTime);
    }
}
