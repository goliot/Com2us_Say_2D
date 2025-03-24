using UnityEngine;

public class TargetEnemy : Enemy
{
    [SerializeField] private float _rotateSpeed = 5f;
    private bool _isDirSet = false;

    private void OnDisable()
    {
        _isDirSet = false;
    }

    private void Update()
    {
        if(!_isDirSet)
        {
            SetDir();
        }
        TargetMovement();
    }

    private void SetDir()
    {
        _isDirSet = true;

        _direction = Vector3.Normalize(TargetPlayer.position - transform.position);
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    private void TargetMovement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime, Space.World);
    }
}
