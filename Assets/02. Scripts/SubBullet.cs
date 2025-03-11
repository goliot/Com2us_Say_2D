using UnityEngine;

public class SubBullet : Bullet
{
    [SerializeField] private float Weight = 5f;

    protected override void SnakeMovement()
    {
        _lerpTime += Time.deltaTime;
        if (_lerpTime > 2 * Mathf.PI)
        {
            _lerpTime = 0f;
        }

        float h = IsLeftBullet ? Weight * Mathf.Cos(Frequency * _lerpTime) : Weight * -Mathf.Cos(Frequency * _lerpTime);
        
        _direction = new Vector3(h, 1, 0).normalized;
        transform.Translate(h * Speed * Time.deltaTime, Speed * Time.deltaTime, 0);
    }
}
