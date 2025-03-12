using UnityEngine;

public class FollowEnemy : Enemy
{
    private void Update()
    {
        _direction = Vector3.Normalize(TargetPlayer.position - transform.position);

        TargetMovement();
    }

    private void TargetMovement()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
    }
}
