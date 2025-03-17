using UnityEngine;

public class FollowEnemy : Enemy
{
    private void Update()
    {
        _direction = Vector3.Normalize(TargetPlayer.position - transform.position);

        TargetMovement();
        RotateTowardTarget();
    }

    private void TargetMovement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
    }

    private void RotateTowardTarget()
    {   
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}
