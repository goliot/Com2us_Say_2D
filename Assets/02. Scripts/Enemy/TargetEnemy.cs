using UnityEngine;

public class TargetEnemy : Enemy
{
    [SerializeField] private float _rotateSpeed = 5f;

    private void OnEnable()
    {
        _direction = Vector3.Normalize(TargetPlayer.position - transform.position);

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    private void Update()
    {
        TargetMovement();
    }

    private void TargetMovement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime, Space.World);
    }
}
